using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
    
    [TestCleanup]
    public void CloseDbConnection()
    {
        SqliteConnection.Close();
    }
}