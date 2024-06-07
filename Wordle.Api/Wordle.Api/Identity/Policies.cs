using Microsoft.AspNetCore.Authorization;

namespace Wordle.Api.Identity;
public static class Policies
{
    public const string RandomAdmin = "RandomAdmin";
    public const string AddOrDeleteWord = "EditWord";

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
    public static void AddOrDeleteWordPolicy(AuthorizationPolicyBuilder policy)
    {
        policy.RequireClaim(Claims.MasterOfTheUniverse, "true");
        policy.RequireAssertion(context =>
        {
            var birthdayString = context.User.Claims.FirstOrDefault(f => f.Type == Claims.BirthDate);

            if (DateTime.TryParse(birthdayString?.Value, out DateTime birthday))
            {
                return (DateTime.Now.Year - birthday.Year) switch
                {
                    > 21 => true,
                    21 => DateTime.Now.Month >= birthday.Month && DateTime.Now.Day >= birthday.Day,
                    _ => false
                };
            }
            return false;
        });
        }
 }

