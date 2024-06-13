using Microsoft.AspNetCore.Authorization;

namespace Wordle.Api.Identity
{
    public static class Authorize
    {
        public const string EliteAdmin = "EliteAdmin";
        public const string MasterOfTheUniverse = "MasterOfTheUniverse";

        public static void EliteAdminPolicy(AuthorizationPolicyBuilder policy)
        {
            policy.RequireRole(Roles.Admin);
            policy.RequireAssertion(context =>
            {
                var randomClaim = context.User.Claims.FirstOrDefault(c => c.Type == Claims.Random);
                if (randomClaim != null && double.TryParse(randomClaim.Value, out double random))
                {
                    return random > 0.5;
                }
                return false;
            });
        }

        public static void MasterOfTheUniversePolicy(AuthorizationPolicyBuilder policy)
        {
            policy.RequireClaim(Claims.MasterLevel, "true");
            policy.RequireAssertion(context =>
            {
                var birthDateClaim = context.User.Claims.FirstOrDefault(c => c.Type == Claims.BirthDate);
                if (birthDateClaim != null && DateTime.TryParse(birthDateClaim.Value, out DateTime birthDate))
                {
                    var age = DateTime.Now.Year - birthDate.Year;
                    if (birthDate > DateTime.Now.AddYears(-age)) age--;
                    
                    return age >= 21;
                }
                return false;
            });
        }
    }
}
