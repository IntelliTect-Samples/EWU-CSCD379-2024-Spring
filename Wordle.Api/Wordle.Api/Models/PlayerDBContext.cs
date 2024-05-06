using Microsoft.EntityFrameworkCore;

namespace Wordle.Api.Models
{
    public class PlayerDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public PlayerDbContext(DbContextOptions<PlayerDbContext> options)
            : base(options)
        {
        }
    }
}
