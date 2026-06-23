namespace API.Settings;

public sealed class AuthSettings
{
    public required string InitialAdminEmail { get; set; }
    public required string InitialAdminPassword { get; set; }
    public required string JwtSecret { get; set; }
    public required string JwtIssuer { get; set; }
    public required string JwtAudience { get; set; }
    public int AccessTokenExpiryHours { get; set; } = 4;
    public int RefreshTokenExpiryDays { get; set; } = 30;
}
