using Microsoft.AspNetCore.Identity;
using System;
using Wordle.Api.Models;

namespace Wordle.Api.Identity
{
    public static class IdentitySeed
    {
        public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, WordleDbContext db)
        {
            // Seed Roles
            await SeedRolesAsync(roleManager);

            // Seed Users
            await SeedUsersAsync(userManager);
        }

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            // Seed Admin Role
            if (!await roleManager.RoleExistsAsync(Roles.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
            }
        }

        private static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            // Seed Admin User (Over 21)
            if (await userManager.FindByEmailAsync("admin@intellitect.com") == null)
            {
                AppUser adminUser = new AppUser
                {
                    UserName = "admin@intellitect.com",
                    Email = "admin@intellitect.com",
                    Birthday = new DateTime(1980, 1, 1) // Over 21
                };

                IdentityResult adminResult = await userManager.CreateAsync(adminUser, "P@ssw0rd123");

                if (adminResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, Roles.Admin);
                    await userManager.AddClaimAsync(adminUser, new System.Security.Claims.Claim(Claims.MasterLevel, "true"));
                    await userManager.AddClaimAsync(adminUser, new System.Security.Claims.Claim(Claims.BirthDate, adminUser.Birthday.ToString("yyyy-MM-dd")));
                }
            }

            // Seed Young User (Under 21)
            if (await userManager.FindByEmailAsync("younguser@intellitect.com") == null)
            {
                AppUser youngUser = new AppUser
                {
                    UserName = "younguser@intellitect.com",
                    Email = "younguser@intellitect.com",
                    Birthday = new DateTime(2010, 1, 1) // Under 21
                };

                IdentityResult youngUserResult = await userManager.CreateAsync(youngUser, "P@ssw0rd123");
            }
        }
    }
}
