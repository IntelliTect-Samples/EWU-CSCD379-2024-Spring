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
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        // Seed Roles
        if (!await roleManager.RoleExistsAsync(Roles.Admin))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
        }

        if(!await roleManager.RoleExistsAsync(Roles.Awesome))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Awesome));
        }
    }

    private static async Task SeedAdminUserAsync(UserManager<AppUser> userManager)
    {
        // Seed Admin User -> Can Add/Delete Words
        if (await userManager.FindByEmailAsync("Admin@intellitect.com") == null)
        {
            AppUser user = new AppUser
            {
                UserName = "Admin@intellitect.com",
                Email = "Admin@intellitect.com",
                BirthDate = new DateOnly(1999, 01, 01),
                IsMasterOfTheUniverse = true
            };

            IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Admin);
            }
        }

        //Seed Master of the Universe -> Cannnot Add/Delete Words wrong Birthdate
        if (await userManager.FindByEmailAsync("Master@intellitect.com") == null)
        {
            AppUser user = new AppUser
            {
                UserName = "Master@intellitect.com",
                Email = "Master@intellitect.com",
                BirthDate = new DateOnly(2020, 01, 01),
                IsMasterOfTheUniverse = true
            };

            IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Awesome);
            }

        }

        // Seed Awesome User -> Cannot Add/Delete not master of the universe
        if (await userManager.FindByEmailAsync("Awesome@intellitect.com") == null)
        {
            AppUser user = new AppUser
            {
                UserName = "Awesome@intellitect.com",
                Email = "Awesome@intellitect.com",
                BirthDate = new DateOnly(1999, 01, 01),
                IsMasterOfTheUniverse = false
                
            };

            IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Awesome);
            }
        }
    }
}