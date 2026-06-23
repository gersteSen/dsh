using API._Auth;
using API._Auth.Repository;
using API._Auth.Service;
using API._Instrument.Repository;
using API._Instrument.Service;
using API._Lesson.Repository;
using API._Lesson.Service;
using API._Material.Repository;
using API._Material.Service;
using API._Room.Repository;
using API._Room.Service;
using API._Student.Repository;
using API._Student.Service;
using API._Teacher.Repository;
using API._Teacher.Services;
using API.Infrastructure;
using API.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DSH API",
        Version = "v1",
        Description = "Drumschule Harsch API"
    });
});

builder.Services.AddDbContext<DshDatabaseContext>(options =>
    DshDatabaseContext.ConfigureDb(options, builder.Configuration)
);

builder.Services.AddDbContext<AuthDbContext>(options =>
    AuthDbContext.ConfigureDb(options, builder.Configuration)
);

var authSettings = builder.Configuration.GetSection("Auth").Get<AuthSettings>()
    ?? throw new InvalidOperationException("Auth-Konfiguration fehlt in appsettings.json.");
builder.Services.AddSingleton(authSettings);

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IInstrumentRepository, InstrumentRepository>();
builder.Services.AddScoped<IInstrumentService, InstrumentService>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<ILessonService, LessonService>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomService, RoomService>();



builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "DSH API v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var authDb = scope.ServiceProvider.GetRequiredService<AuthDbContext>();
    await authDb.Database.MigrateAsync();

    await AuthSeeder.SeedAsync(scope.ServiceProvider);
}

app.Run();
