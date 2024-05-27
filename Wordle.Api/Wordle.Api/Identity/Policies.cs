using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.ComponentModel;

namespace Wordle.Api.Identity;
public static class Policies
{
    public const string RandomAdmin = "RandomAdmin";

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
        policy.RequireClaim(Claims.MasterOfTheUniverse);
        policy.RequireAssertion(context =>
        {
            var ageString = context.User.Claims.FirstOrDefault(f => f.Type == Claims.BirthDate);
            if (ageString != null)
            {
                int age;
                if (int.TryParse(ageString.Value, out age))
                {
                    return age >= 21;
                }
            }
            return false;
        });
        }
 }

