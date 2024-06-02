using Microsoft.AspNetCore.Identity;

namespace Wordle.Api.Models
{
    public class AppUser : IdentityUser
    {
        public int GameCount { get; set; }

        public double AverageAttempts { get; set; }

        public int AverageSecondsPerGame { get; set; }

        public DateTime Birthday { get; set; }
    }
}
