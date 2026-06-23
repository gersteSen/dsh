using API._Auth.Dto;
using Microsoft.AspNetCore.Identity;

namespace API._Auth.Repository;

public class UserRepository(UserManager<IdentityUser> userManager) : IUserRepository
{
    public async Task<string> CreateUserAsync(CreateUserDto dto, CancellationToken cancellationToken = default)
    {
        var existing = await userManager.FindByEmailAsync(dto.Email);
        if (existing is not null)
            throw new InvalidOperationException($"Ein Benutzer mit der E-Mail '{dto.Email}' existiert bereits.");

        var user = new IdentityUser
        {
            UserName = dto.Email,
            Email = dto.Email,
            EmailConfirmed = true,
        };

        var result = await userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
            throw new InvalidOperationException(FormatErrors(result));

        foreach (var role in dto.Roles)
        {
            var roleResult = await userManager.AddToRoleAsync(user, role);
            if (!roleResult.Succeeded)
                throw new InvalidOperationException(FormatErrors(roleResult));
        }

        return user.Id;
    }

    public async Task UpdateUserAsync(UpdateUserDto dto, CancellationToken cancellationToken = default)
    {
        var user = await userManager.FindByIdAsync(dto.Id)
            ?? throw new KeyNotFoundException($"Kein Benutzer mit der Id '{dto.Id}' gefunden.");

        if (user.Email != dto.Email)
        {
            user.Email = dto.Email;
            user.UserName = dto.Email;
            user.NormalizedEmail = dto.Email.ToUpperInvariant();
            user.NormalizedUserName = dto.Email.ToUpperInvariant();
        }

        var updateResult = await userManager.UpdateAsync(user);
        if (!updateResult.Succeeded)
            throw new InvalidOperationException(FormatErrors(updateResult));

        var currentRoles = await userManager.GetRolesAsync(user);
        var toRemove = currentRoles.Except(dto.Roles).ToList();
        var toAdd = dto.Roles.Except(currentRoles).ToList();

        if (toRemove.Count > 0)
        {
            var removeResult = await userManager.RemoveFromRolesAsync(user, toRemove);
            if (!removeResult.Succeeded)
                throw new InvalidOperationException(FormatErrors(removeResult));
        }

        if (toAdd.Count > 0)
        {
            var addResult = await userManager.AddToRolesAsync(user, toAdd);
            if (!addResult.Succeeded)
                throw new InvalidOperationException(FormatErrors(addResult));
        }
    }

    public async Task DeactivateUserAsync(string userId, CancellationToken cancellationToken = default)
    {
        var user = await userManager.FindByIdAsync(userId)
            ?? throw new KeyNotFoundException($"Kein Benutzer mit der Id '{userId}' gefunden.");

        await userManager.SetLockoutEnabledAsync(user, true);
        await userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue);
    }

    public async Task<UserDto> GetUserByIdAsync(string userId, CancellationToken cancellationToken = default)
    {
        var user = await userManager.FindByIdAsync(userId)
            ?? throw new KeyNotFoundException($"Kein Benutzer mit der Id '{userId}' gefunden.");

        return await MapToDtoAsync(user);
    }

    public async Task<List<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken = default)
    {
        var users = userManager.Users.ToList();
        var dtos = new List<UserDto>();

        foreach (var user in users)
            dtos.Add(await MapToDtoAsync(user));

        return dtos;
    }

    private async Task<UserDto> MapToDtoAsync(IdentityUser user)
    {
        var roles = await userManager.GetRolesAsync(user);
        var isActive = !(user.LockoutEnd.HasValue && user.LockoutEnd > DateTimeOffset.UtcNow);

        return new UserDto
        {
            Id = user.Id,
            Email = user.Email ?? string.Empty,
            UserName = user.UserName ?? string.Empty,
            IsActive = isActive,
            Roles = roles,
        };
    }

    private static string FormatErrors(IdentityResult result)
        => string.Join(", ", result.Errors.Select(e => e.Description));
}
