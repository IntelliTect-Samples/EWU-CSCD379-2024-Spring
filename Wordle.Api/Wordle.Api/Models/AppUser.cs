using Microsoft.AspNetCore.Identity;

namespace Wordle.Api.Models;
public class AppUser : IdentityUser
{
    public int GameCount { get; set; }
    public double AverageAttempts { get; set; }
    public int AverageSecondsPerGame { get; set; }

    public DateOnly BirthDate { get; set; }
    public bool IsMasterOfTheUniverse { get; set; }
}
