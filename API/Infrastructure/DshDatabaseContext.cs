using API.Configuration;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace API.Infrastructure;

public class DshDatabaseContext: DbContext
{
    public DshDatabaseContext(DbContextOptions<DshDatabaseContext> options) : base(options)
    {
     }
    
    public static NpgsqlDataSource BuildDataSource(IConfiguration configuration)
    {
        var host = ConfigurationHelper.GetConfigurationValue(configuration, "ConnectionStrings:DSH_HOST",
            "DSH_HOST");
        var port = ConfigurationHelper.GetConfigurationValue(configuration, "ConnectionStrings:DSH_PORT",
            "DSH_PORT");
        var database =
            ConfigurationHelper.GetConfigurationValue(configuration, "ConnectionStrings:DSH_DB", "DSH_DB");
        var username = ConfigurationHelper.GetConfigurationValue(configuration, "ConnectionStrings:DSH_USERNAME",
            "DSH_USERNAME");
        var password = ConfigurationHelper.GetConfigurationValue(configuration, "ConnectionStrings:DSH_PASSWORD",
            "DSH_PASSWORD");

        var connectionString = new NpgsqlConnectionStringBuilder
        {
            Host = host,
            Port = port != null ? int.Parse(port) : 5432,
            Database = database,
            Username = username,
            Password = password,
        };

        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString.ConnectionString);
        dataSourceBuilder.EnableDynamicJson();
        return dataSourceBuilder.Build();
    }
}