using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.ComponentModel;

namespace Wordle.Api.Identity;
public static class Policies
{
    public const string RandomAdmin = "RandomAdmin";
    public const string EditWord = "EditWord";

    public static void RandomAdminPolicy(AuthorizationPolicyBuilder policy)
    {
        policy.RequireRole(Roles.Admin);
        policy.RequireAssertion(context =>
        {
            var random = context.User.Claims.FirstOrDefault(c => c.Type == Claims.Random);
            if (Double.TryParse(random?.Value, out double result))
            {
                return result > 0.5;
            }
            return false;
        });
    }
    public static void EditWordPolicy(AuthorizationPolicyBuilder policy)
    {
        policy.RequireClaim(Claims.MasterOfTheUniverse, "true");
        policy.RequireAssertion(context =>
        {
            var birthdayString = context.User.Claims.FirstOrDefault(f => f.Type == Claims.BirthDate);
            if (birthdayString != null)
            {
                DateTime birthday;
                if (DateTime.TryParse(birthdayString.Value, out birthday))
                {
                    int birthYear = birthday.Year;
                    return DateTime.UtcNow.Year - birthYear >= 21;
                }
            }
            return false;
        });
        }
 }

