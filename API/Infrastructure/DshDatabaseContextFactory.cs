using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API.Infrastructure;

// Wird für die Migrations benötigt, damit die Migrations auch außerhalb der API (z.B. in der Test-Assembly) erstellt werden können
public class DshDatabaseContextFactory : IDesignTimeDbContextFactory<DshDatabaseContext>
{
    public DshDatabaseContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<DshDatabaseContext>();
        DshDatabaseContext.ConfigureDb(optionsBuilder, configuration);

        return new DshDatabaseContext(optionsBuilder.Options);
    }
}

