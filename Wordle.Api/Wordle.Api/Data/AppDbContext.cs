using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Models;

namespace Wordle.Api.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

	public DbSet<Player> Players { get; set; }
	public DbSet<WordOfTheDay> WordsOfTheDays { get; set; }
	public DbSet<Game> Games { get; set; }
	public DbSet<Word> Words { get; set; }
}
