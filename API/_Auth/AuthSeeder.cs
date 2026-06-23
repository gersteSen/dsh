using API.Settings;
using Microsoft.AspNetCore.Identity;

namespace API._Auth;

public static class AuthSeeder
{
    public static readonly string[] Roles = ["TeacherRole", "StudentRole", "AdminRole"];

    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var authSettings = serviceProvider.GetRequiredService<AuthSettings>();

        await SeedRolesAsync(roleManager, logger);
        await SeedInitialUserAsync(userManager, authSettings, logger);
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager, ILogger logger)
    {
        foreach (var role in Roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
                logger.LogInformation("Rolle '{Role}' wurde angelegt.", role);
            }
        }
    }

    private static async Task SeedInitialUserAsync(
        UserManager<IdentityUser> userManager,
        AuthSettings authSettings,
        ILogger logger)
    {
        var existingUser = await userManager.FindByEmailAsync(authSettings.InitialAdminEmail);

        if (existingUser is not null)
        {
            logger.LogInformation("Initial-Admin-User '{Email}' ist bereits vorhanden.", authSettings.InitialAdminEmail);
            return;
        }

        var user = new IdentityUser
        {
            UserName = authSettings.InitialAdminEmail,
            Email = authSettings.InitialAdminEmail,
            EmailConfirmed = true,
        };

        var result = await userManager.CreateAsync(user, authSettings.InitialAdminPassword);

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "AdminRole");
            logger.LogInformation("Initial-Admin-User '{Email}' wurde erfolgreich angelegt.", authSettings.InitialAdminEmail);
        }
        else
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            logger.LogError("Fehler beim Anlegen des Initial-Admin-Users '{Email}': {Errors}", authSettings.InitialAdminEmail, errors);
        }
    }
}
