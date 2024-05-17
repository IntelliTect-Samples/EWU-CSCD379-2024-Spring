using Microsoft.EntityFrameworkCore;
using Wordle.Api.Models;

namespace Wordle.Api.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

	public DbSet<Player> Players { get; set; }
	public DbSet<WordOfTheDay> WordsOfTheDays { get; set; }
}
