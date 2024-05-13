using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Wordle.Api.Models;

namespace Wordle.Api.Tests;
public class DatabaseTestBase
{
    private SqliteConnection SqliteConnection { get; set; } = null!;
    protected DbContextOptions<WordleDbContext> Options { get; private set; } = null!;

    private static ILoggerFactory GetLoggerFactory()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddLogging(builder =>
        {
            builder.AddConsole();
        });
        return serviceCollection.BuildServiceProvider().
            GetService<ILoggerFactory>()!;
    }

    [TestInitialize]
    public void InitializeDb()
    {
        SqliteConnection = new SqliteConnection("DataSource=:memory:");
        SqliteConnection.Open();

        Options = new DbContextOptionsBuilder<WordleDbContext>()
            .UseSqlite(SqliteConnection)
            .UseLoggerFactory(GetLoggerFactory())
            .EnableSensitiveDataLogging()
            .Options;

        using var context = new WordleDbContext(Options);
        context.Database.EnsureCreated();
    }

    public static IEnumerable<PlayerDto> Requests { get; } = new PlayerDto[] {
        new PlayerDto { Name = "Artemis Lightfoot", AverageAttempts = 3, GameCount = 1 },
        new PlayerDto { Name = "Cedric the Bold", AverageAttempts = 2, GameCount = 1 },
        new PlayerDto { Name = "Eldrin Starfire", AverageAttempts = 4, GameCount = 1 },
        new PlayerDto { Name = "Mirabel the Wise", AverageAttempts = 2, GameCount = 1 },
        new PlayerDto { Name = "Thorn Underleaf", AverageAttempts = 1, GameCount = 1 },
        new PlayerDto { Name = "Lilith Darkweaver", AverageAttempts = 2, GameCount = 1 },
    };
}

    [TestCleanup]
    public void CloseDbConnection()
    {
        SqliteConnection.Close();
    }
}
