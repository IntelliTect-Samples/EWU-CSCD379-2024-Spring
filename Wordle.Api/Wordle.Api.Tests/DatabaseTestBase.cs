using Microsoft.EntityFrameworkCore;
using Wordle.Api.Models;
using Microsoft.Data.Sqlite;
using Wordle.Api.Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Wordle.Api.Tests
{
    public abstract class DatabaseTestBase
    {
        private SqliteConnection SqliteConnection { get; set; } = null!;
        protected DbContextOptions<WordleDbContext> Options { get; private set; } = null!;

        [TestInitialize]
        public void InitializeDb()
        {
            SqliteConnection = new SqliteConnection("DataSource=:memory:");
            SqliteConnection.Open();

            Options = new DbContextOptionsBuilder<WordleDbContext>()
                .UseSqlite(SqliteConnection)
                .Options;

            using var context = new WordleDbContext(Options);
            context.Database.EnsureCreated();
        }

        [TestCleanup]
        public void CloseDbConnection()
        {
            SqliteConnection.Close();
        }

        public static IEnumerable<PlayerDto> Requests { get; } =
            new PlayerDto[] {
                new PlayerDto { Name = "Aragorn the Brave", AverageAttempts = 1, GameCount = 1 },
                new PlayerDto { Name = "Legolas the Swift", AverageAttempts = 2, GameCount = 1 },
                new PlayerDto { Name = "Gimli the Stout", AverageAttempts = 2, GameCount = 1 },
                new PlayerDto { Name = "Gandalf the Wise", AverageAttempts = 1, GameCount = 1},
                new PlayerDto { Name = "Frodo the Ringbearer", AverageAttempts = 2, GameCount = 1},
                new PlayerDto { Name = "Samwise the Loyal", AverageAttempts = 1, GameCount = 1},
                new PlayerDto { Name = "Boromir the Bold", AverageAttempts = 2, GameCount = 1},
                new PlayerDto { Name = "Arwen the Fair", AverageAttempts = 1, GameCount = 1},
                new PlayerDto { Name = "Elrond the Sage", AverageAttempts = 2, GameCount = 1},
                new PlayerDto { Name = "Galadriel the Graceful", AverageAttempts = 1, GameCount = 1},
                new PlayerDto { Name = "Saruman the White", AverageAttempts = 2, GameCount = 1}
            };
    }
}

