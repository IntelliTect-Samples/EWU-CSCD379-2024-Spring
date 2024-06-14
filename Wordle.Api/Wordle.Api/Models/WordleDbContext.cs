using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Wordle.Api.Models
{
    public class WordleDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<WordOfTheDay> WordsOfTheDays { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<DailyStats> DailyStats { get; set; } // Add this line

        public WordleDbContext(DbContextOptions<WordleDbContext> options) : base(options)
        {
        }

        // Make sure the identity db context on model creating is called
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
