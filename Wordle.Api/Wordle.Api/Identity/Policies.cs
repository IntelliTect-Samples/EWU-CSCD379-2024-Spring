using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.ComponentModel;

namespace Wordle.Api.Identity;
public static class Policies
{
	public const string RandomAdmin = "RandomAdmin";
	public const string MasterOfTheUniverse = "MasterOfTheUniverse";
	public const string OlderThanTwentyOne = "OlderThanTwentyOne";

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

	public static void MasterOfTheUniversePolicy(AuthorizationPolicyBuilder policy)
	{
		policy.RequireAssertion(context =>
		{
			var motuClaim = context.User.Claims.FirstOrDefault(c => c.Type == Claims.MasterOfTheUniverse);
			if (Boolean.TryParse(motuClaim?.Value, out bool motu))
			{
				return motu;
			}
			return false;
		});
	}

	public static void OlderThanTwentyOnePolicy(AuthorizationPolicyBuilder policy)
	{
		policy.RequireAssertion(context =>
		{
			var birthdateClaim = context.User.Claims.FirstOrDefault(c => c.Type == Claims.BirthDate);
			if (DateOnly.TryParse(birthdateClaim?.Value, out DateOnly birthdate))
			{
				DateOnly now = DateOnly.FromDateTime(DateTime.UtcNow);
				int yearDifference = now.Year - birthdate.Year;
				if (yearDifference > 21)
				{
					return true;
				}
				else if (yearDifference == 21)
				{
					return now.Month >= birthdate.Month ? (now.Day >= birthdate.Day) : false;
				}
				else
				{
					return false;
				}
			}
			return false;
		});
	}
}