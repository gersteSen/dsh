using API.Configuration;
using API.Infrastructure.Config;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace API.Infrastructure;

public class AuthDbContext : IdentityDbContext<IdentityUser>
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
    }

    public static void ConfigureDb(DbContextOptionsBuilder options, IConfiguration configuration)
    {
        var host = ConfigurationHelper.GetConfigurationValue(configuration, "ConnectionStrings:DSH_HOST", "DSH_HOST");
        var port = ConfigurationHelper.GetConfigurationValue(configuration, "ConnectionStrings:DSH_PORT", "DSH_PORT");
        var database = ConfigurationHelper.GetConfigurationValue(configuration, "ConnectionStrings:DSH_DB", "DSH_DB");
        var username = ConfigurationHelper.GetConfigurationValue(configuration, "ConnectionStrings:DSH_USERNAME", "DSH_USERNAME");
        var password = ConfigurationHelper.GetConfigurationValue(configuration, "ConnectionStrings:DSH_PASSWORD", "DSH_PASSWORD");

        var connectionString = new NpgsqlConnectionStringBuilder
        {
            Host = host,
            Port = port != null ? int.Parse(port) : 5432,
            Database = database,
            Username = username,
            Password = password,
        };

        options.UseNpgsql(connectionString.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new AuthUserConfig());
        builder.ApplyConfiguration(new AuthRoleConfig());
        builder.ApplyConfiguration(new AuthUserRoleConfig());
        builder.ApplyConfiguration(new AuthUserClaimConfig());
        builder.ApplyConfiguration(new AuthUserLoginConfig());
        builder.ApplyConfiguration(new AuthUserTokenConfig());
        builder.ApplyConfiguration(new AuthRoleClaimConfig());
    }
}
