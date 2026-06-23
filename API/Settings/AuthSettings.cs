namespace API.Settings;

public sealed class AuthSettings
{
    public required string InitialAdminEmail { get; set; }
    public required string InitialAdminPassword { get; set; }
}
