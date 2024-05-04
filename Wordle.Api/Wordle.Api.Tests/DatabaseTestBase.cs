using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Microsoft.Data.Sqlite;
using Wordle.Api.Dtos;

namespace Wordle.Api.Tests;
public abstract class DatabaseTestBase
{
	private SqliteConnection SqliteConnection { get; set; } = null!;
	protected DbContextOptions<AppDbContext> Options { get; private set; } = null!;

	[TestInitialize]
	public void InitializeDb()
	{
		SqliteConnection = new SqliteConnection("DataSource=:memory:");
		SqliteConnection.Open();

		Options = new DbContextOptionsBuilder<AppDbContext>()
			.UseSqlite(SqliteConnection)
			.Options;

		using var context = new AppDbContext(Options);
		context.Database.EnsureCreated();
	}

	[TestCleanup]
	public void CloseDbConnection()
	{
		SqliteConnection.Close();
	}

	public static IEnumerable<PlayerDto> Requests { get; } =
		new PlayerDto[] {
			new PlayerDto { Name = "Jimbob I", AverageAttempts = 1, GameCount = 1 },
			new PlayerDto { Name = "Jimbob II", AverageAttempts = 2, GameCount = 1 },
			new PlayerDto { Name = "Jimbob III", AverageAttempts = 2, GameCount = 1 },
			new PlayerDto { Name = "Jimbob Jr I", AverageAttempts = 1, GameCount = 1},
			new PlayerDto { Name = "Jimbob Jr II", AverageAttempts = 2, GameCount = 1},
			new PlayerDto { Name = "Jimbob Jr III", AverageAttempts = 1, GameCount = 1},
			new PlayerDto { Name = "Jimbob Sr I", AverageAttempts = 2, GameCount = 1},
			new PlayerDto { Name = "Jimbob Sr II", AverageAttempts = 1, GameCount = 1},
			new PlayerDto { Name = "Jimbob Sr III", AverageAttempts = 2, GameCount = 1},
			new PlayerDto { Name = "Jimbob Sr IIII", AverageAttempts = 1, GameCount = 1},
			new PlayerDto { Name = "Jimbobby", AverageAttempts = 2, GameCount = 1}
		};
}
