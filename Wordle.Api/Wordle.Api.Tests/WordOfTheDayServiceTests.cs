using Microsoft.EntityFrameworkCore;
using Wordle.Api.Models;
using Wordle.Api.Services;
using Microsoft.Data.Sqlite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Wordle.Api.Tests
{
    [TestClass]
    public class WordOfTheDayServiceTests : DatabaseTestBase
    {
        private WordOfTheDayService _wordOfTheDayService;

        [TestInitialize]
        public void Setup()
        {
            InitializeDb();

            using var context = new WordleDbContext(Options);
            _wordOfTheDayService = new WordOfTheDayService(context);
        }

        [TestCleanup]
        public void Teardown()
        {
            CloseDbConnection();
        }

        [TestMethod]
        public async Task GetRandomWord_ReturnsWord()
        {
            using var context = new WordleDbContext(Options);
            var wordOfTheDayService = new WordOfTheDayService(context);

            // Act
            var word = await wordOfTheDayService.GetRandomWord();

            // Assert
            Assert.IsNotNull(word);
        }

        [TestMethod]
        public async Task GetWordOfTheDay_ReturnsWord()
        {
            using var context = new WordleDbContext(Options);
            var wordOfTheDayService = new WordOfTheDayService(context);

            // Act
            var word = await wordOfTheDayService.GetWordOfTheDay(DateOnly.FromDateTime(DateTime.Now));

            // Assert
            Assert.IsNotNull(word);
        }
    }
}
