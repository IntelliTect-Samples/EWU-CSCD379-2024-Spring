using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Wordle.Api.Identity
{
  public static class Policies
  {
    public const string MasterOfTheUniverse = "MasterOfTheUniverse";
    public const string IsTwentyOne = "IsTwentyOne";

    public static void AddRemoveWordPoliciy(AuthorizationPolicyBuilder policy)
    {
      policy.RequireClaim(Claims.MasterOfTheUniverse, "true");
      policy.RequireAssertion(date =>{
          // get bday
          var birthdayDate = date.User.Claims.FirstOrDefault(i => i.Type == Claims.Birthdate);
          while(birthdayDate != null){
            DateTime paresedBDay;
            // parse bday to dateTime format
            if(DateTime.TryParse(birthdayDate?.Value, out paresedBDay)){
              // get age from year
              int age = DateTime.Today.Year - paresedBDay.Year;
              // if this years date has not happened subtract a year from age
              if(DateTime.Today < paresedBDay.AddYears(age)){
                age--;
              }
              // else return if age is greater then 21
              return age >= 21;
            }
          }
          // bday not found
          return false;
      });
    }
  }
}

