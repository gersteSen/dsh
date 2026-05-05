namespace API.Configuration;

public class ConfigurationHelper
{
    public static string? GetConfigurationValue(IConfiguration configuration, string key, string environmentVariable)
    {
        var envValue = Environment.GetEnvironmentVariable(environmentVariable);
        return !string.IsNullOrEmpty(envValue) ? envValue : configuration.GetValue<string>(key);
    }
}