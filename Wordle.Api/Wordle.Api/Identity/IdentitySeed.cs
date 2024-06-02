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
        // Seed Roles
        /*if (!await roleManager.RoleExistsAsync(Roles.Awesome))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Awesome));
        }*/
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

        // Seed Admin User
        if (await userManager.FindByEmailAsync("nmarsee@ewu.edu") == null)
        {
            AppUser user = new AppUser
            {
                UserName = "nmarsee@ewu.edu",
                Email = "nmarsee@ewu.edu",
                Birthday = new DateOnly(2002, 5, 29, new System.Globalization.GregorianCalendar())
            };

            IdentityResult result = userManager.CreateAsync(user, "nmarsee1").Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Admin);
            }
        }

        // Seed Admin User
        if (await userManager.FindByEmailAsync("madams41@ewu.edu") == null)
        {
            AppUser user = new AppUser
            {
                UserName = "madams41@ewu.edu",
                Email = "madams41@ewu.edu",
                Birthday = new DateOnly(2003, 1, 20, new System.Globalization.GregorianCalendar())
            };

            IdentityResult result = userManager.CreateAsync(user, "madams1").Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Admin);
            }
        }

        if (await userManager.FindByEmailAsync("YoungUser@intellitect.com") == null)
        {
            AppUser user = new AppUser
            {
                UserName = "YoungUser@intellitect.com",
                Email = "YoungUser@intellitect.com",
                Birthday = new DateOnly(2016, 1, 1, new System.Globalization.GregorianCalendar())
            };

            IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

            /*if (result.Succeeded)
            {
                await userManager.AddClaimAsync(user, new Claim(Claims.MasterOfTheUniverse, true));
            }*/
        }

        if (await userManager.FindByEmailAsync("User@intellitect.com") == null)
        {
            AppUser user = new AppUser
            {
                UserName = "User@intellitect.com",
                Email = "User@intellitect.com",
                Birthday = new DateOnly(2000, 1, 1, new System.Globalization.GregorianCalendar())
            };

            IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

            /*if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Awesome);
            }*/
        }
    }
}