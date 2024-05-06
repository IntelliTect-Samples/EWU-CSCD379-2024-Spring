using Microsoft.EntityFrameworkCore;

namespace Wordle.Api.Models
{
    public class PlayerDBContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public WordleDbContext(DbContextOptions<WordleDbContext> options)
            : base(options)
        {
        }
    }
}
