using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Vanguard.Web.Models;

namespace Vanguard.Web.Data
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAndAdmin(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Create roles
            string[] roleNames = { "GlobalAdmin", "CommandStaff", "UniverseLeader", "FactionLeader", "BranchLeader", "UnitLeader", "ProspectiveMember", "FullMember", "InactiveMember" };

            foreach (var role in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Create master admin user
            var adminEmail = "admin@example.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var user = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    DisplayName = "ANEC-23"
                };

                var result = await userManager.CreateAsync(user, "Admin123!!321nimdA");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
            else if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}