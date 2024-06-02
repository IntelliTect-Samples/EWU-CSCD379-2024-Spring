using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.ComponentModel;

namespace Wordle.Api.Identity;
public static class Policies
{
    public const string AddOrRemoveWords = "AddOrRemoveWords";

    /*public static void RandomAdminPolicy(AuthorizationPolicyBuilder policy)
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
    }*/
    public static void AddOrRemoveWordsPolicy(AuthorizationPolicyBuilder policy)
    {
        //policy.RequireRole(Roles.Admin);
        policy.RequireAssertion(context =>
        {
            var master = context.User.Claims.FirstOrDefault(c => c.Type == Claims.MasterOfTheUniverse);
            var age = context.User.Claims.FirstOrDefault(c => c.Type == Claims.Age);
            return (master != null && age != null && master.Value.Equals("true") && int.Parse(age.Value) >= 21);
        });
    }
}