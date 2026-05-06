using API._Instrument;
using API._Lesson;
using API._Material;
using API._Room;
using API._Student;
using API._Teacher;
using API.Configuration;
using API.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace API.Infrastructure;

public class DshDatabaseContext : DbContext
{
    public DshDatabaseContext(DbContextOptions<DshDatabaseContext> options) : base(options)
    {
    }

    public static void ConfigureDb(DbContextOptionsBuilder options, IConfiguration configuration)
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

        options.UseNpgsql(connectionString.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TeacherConfig());
        modelBuilder.ApplyConfiguration(new StudentConfig());
        modelBuilder.ApplyConfiguration(new InstrumentConfig());
        modelBuilder.ApplyConfiguration(new RoomConfig());
        modelBuilder.ApplyConfiguration(new MaterialConfig());
        modelBuilder.ApplyConfiguration(new LessonConfig());
    }

    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Instrument> Instruments { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
}