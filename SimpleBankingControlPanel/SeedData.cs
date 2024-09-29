using Microsoft.AspNetCore.Identity;
using SimpleBankingControlPanel.Domain;

namespace SimpleBankingControlPanel;

public static class SeedData
{
    public static async Task EnsureSeedData(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        const string adminEmail = "admin@localhost";
        const string adminPassword = "ComplexPassword123!";

        if (!roleManager.RoleExistsAsync("Admin").Result) await roleManager.CreateAsync(new IdentityRole("Admin"));
        if (!roleManager.RoleExistsAsync("User").Result) await roleManager.CreateAsync(new IdentityRole("User"));

        if (userManager.FindByEmailAsync(adminEmail).Result == null)
        {
            var adminUser = new User
            {
                UserName = adminEmail,
                Email = adminEmail,
                FirstName = "Admin",
                LastName = "User"
            };

            var result = await userManager.CreateAsync(adminUser, adminPassword);

            if (result.Succeeded) await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}