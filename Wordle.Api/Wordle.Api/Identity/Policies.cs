using Microsoft.AspNetCore.Authorization;

namespace Wordle.Api.Identity
{
    public static class Policies
    {

        public const string RandomAdmin = "RandomAdmin";
        public const string CanAddDeleteWords = "CanAddDeleteWords";

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

        public static void CanAddDeleteWordsPolicy(AuthorizationPolicyBuilder policy)
        {

            policy.RequireAssertion(context =>
            {
                var birthdateClaim = context.User.Claims.FirstOrDefault(c => c.Type == Claims.BirthDate);
                if (birthdateClaim == null)
                {
                    return false;
                }

                if (DateTime.TryParse(birthdateClaim?.Value, out DateTime birthdate))
                {
                    var age = DateTime.Today.Year - birthdate.Year;
                    if (birthdate > DateTime.Today.AddYears(-age))
                    {
                        age--;
                    }

                    return age >= 21;
                }

                return false;

            });
            
                //policy.RequireAssertion(context =>
                //{
                //    var birthdateClaim = context.User.Claims.FirstOrDefault(c => c.Type == Claims.BirthDate);
                //    if (birthdateClaim != null)
                //    {
                //        return false;
                //    }

                //    if (DateTime.TryParse(birthdateClaim.Value, out DateTime birthdate))
                //    {
                //        var age = DateTime.Today.Year - birthdate.Year;
                //        if (birthdate > DateTime.Today.AddYears(-age))
                //        {
                //            age--;
                //        }

                //        return age >= 21;
                //    }

                //    return false;
                //});



            
        }
    }
}
