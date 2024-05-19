using Microsoft.EntityFrameworkCore;

namespace Wordle.Api.Models
{
    public class WordleDbContext : DbContext
    {
        public DbSet<WordOfTheDay> WordsOfTheDays { get; set; }
        public DbSet<WordOfTheDayGame> WordOfTheDayGames { get; set; }
        public DbSet<Player> Players { get; set; }
        public WordleDbContext(DbContextOptions<WordleDbContext> options) : base(options)
        {
        }
    }
}
