using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Security.Claims;
using System;
using Wordle.Api.Models;

namespace Wordle.Api.Identity;
public static class IdentitySeed
{
    public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, WordleDbContext db)
    {
        // Seed Roles
        await SeedRolesAsync(roleManager);

        // Seed Admin User
        await SeedAdminUserAsync(userManager);

        await SeedOtherUsersAsync(userManager);
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        // Seed Roles
        if (!await roleManager.RoleExistsAsync(Roles.Admin))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
        }
    }

    private static async Task SeedAdminUserAsync(UserManager<AppUser> userManager)
    {
        // Seed Admin User
        if (await userManager.FindByEmailAsync("Admin@intellitect.com") == null)
        {
            AppUser user = new AppUser
            {
                UserName = "Admin@intellitect.com",
                Email = "Admin@intellitect.com"
            };

            IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Admin);
            }
        }
    }

    private static async Task SeedOtherUsersAsync(UserManager<AppUser> userManager)
    {
           
        if (await userManager.FindByEmailAsync("user1@example.com") == null)
        {
            var user1 = new AppUser
            {
                UserName = "user1@example.com",
                Email = "user1@example.com",
                Birthdate = new DateTime(2000, 1, 1),
                //Claims = new List<string> { Claims.MasterOfTheUniverse }
                //Need to find a way to add claims
            };
              await userManager.CreateAsync(user1, "password1");
        }
            // Add more users as needed
    }
}
