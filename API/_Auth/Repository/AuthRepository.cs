using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using API._Auth.Dto;
using API.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace API._Auth.Repository;

public class AuthRepository(
    UserManager<IdentityUser> userManager,
    SignInManager<IdentityUser> signInManager,
    AuthSettings authSettings) : IAuthRepository
{
    private const string RefreshTokenProvider = "DSH";
    private const string RefreshTokenName = "RefreshToken";

    public async Task<AuthResponseDto> LoginAsync(LoginDto dto, CancellationToken cancellationToken = default)
    {
        var user = await userManager.FindByEmailAsync(dto.Email)
            ?? throw new UnauthorizedAccessException("Ungültige E-Mail oder Passwort.");

        var result = await signInManager.CheckPasswordSignInAsync(user, dto.Password, lockoutOnFailure: true);

        if (!result.Succeeded)
        {
            var reason = result.IsLockedOut ? "Konto ist gesperrt." : "Ungültige E-Mail oder Passwort.";
            throw new UnauthorizedAccessException(reason);
        }

        return await GenerateTokenPairAsync(user);
    }

    public async Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenDto dto, CancellationToken cancellationToken = default)
    {
        // Alle User durchsuchen, deren gespeicherter Refresh-Token übereinstimmt
        var allUsers = userManager.Users.ToList();

        foreach (var candidate in allUsers)
        {
            var stored = await userManager.GetAuthenticationTokenAsync(candidate, RefreshTokenProvider, RefreshTokenName);
            if (stored != dto.RefreshToken) continue;

            // Token gefunden – prüfen ob abgelaufen
            var expiryStr = await userManager.GetAuthenticationTokenAsync(candidate, RefreshTokenProvider, "RefreshTokenExpiry");
            if (expiryStr is null || DateTime.Parse(expiryStr) < DateTime.UtcNow)
                throw new UnauthorizedAccessException("Refresh-Token ist abgelaufen. Bitte erneut anmelden.");

            if (candidate.LockoutEnd.HasValue && candidate.LockoutEnd > DateTimeOffset.UtcNow)
                throw new UnauthorizedAccessException("Konto ist gesperrt.");

            return await GenerateTokenPairAsync(candidate);
        }

        throw new UnauthorizedAccessException("Ungültiger Refresh-Token.");
    }

    private async Task<AuthResponseDto> GenerateTokenPairAsync(IdentityUser user)
    {
        var (accessToken, expiresAt) = await BuildAccessTokenAsync(user);
        var refreshToken = await RotateRefreshTokenAsync(user);

        return new AuthResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            ExpiresAt = expiresAt,
        };
    }

    private async Task<(string token, DateTime expiresAt)> BuildAccessTokenAsync(IdentityUser user)
    {
        var roles = await userManager.GetRolesAsync(user);
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.JwtSecret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiresAt = DateTime.UtcNow.AddHours(authSettings.AccessTokenExpiryHours);

        var token = new JwtSecurityToken(
            issuer: authSettings.JwtIssuer,
            audience: authSettings.JwtAudience,
            claims: claims,
            expires: expiresAt,
            signingCredentials: credentials);

        return (new JwtSecurityTokenHandler().WriteToken(token), expiresAt);
    }

    private async Task<string> RotateRefreshTokenAsync(IdentityUser user)
    {
        var refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        var expiry = DateTime.UtcNow.AddDays(authSettings.RefreshTokenExpiryDays).ToString("O");

        await userManager.SetAuthenticationTokenAsync(user, RefreshTokenProvider, RefreshTokenName, refreshToken);
        await userManager.SetAuthenticationTokenAsync(user, RefreshTokenProvider, "RefreshTokenExpiry", expiry);

        return refreshToken;
    }
}
