using Microsoft.EntityFrameworkCore;
using Wordle.Api.Models;
using Wordle.Api.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Wordle.Api.Tests
{
    [TestClass]
    public class WordOfTheDayServiceTests : DatabaseTestBase
    {
        private WordOfTheDayService _wordOfTheDayService = null!;

        [TestInitialize]
        public async Task Setup()
        {
            InitializeDb();

            using var context = new WordleDbContext(Options);
            await Seeder.Seed(context);
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
            // Act
            var word = await _wordOfTheDayService.GetRandomWord();

            // Assert
            Assert.IsNotNull(word);
        }

        [TestMethod]
        public async Task GetWordOfTheDay_ReturnsWord()
        {
            // Act
            var word = await _wordOfTheDayService.GetWordOfTheDay(DateOnly.FromDateTime(DateTime.Now));

            // Assert
            Assert.IsNotNull(word);
        }
    }
}