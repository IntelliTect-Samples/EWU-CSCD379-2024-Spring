using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Wordle.Api.Models
{
    public class WordleDbContext : IdentityDbContext<AppUser>
    {
        public WordleDbContext(DbContextOptions<WordleDbContext> options)
            : base(options)
        {
        }

        public DbSet<Word> Words { get; set; }
        public DbSet<WordOfTheDay> WordsOfTheDays { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
