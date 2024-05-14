using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
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

            using var context = new AppDbContext(Options);
            _wordOfTheDayService = new WordOfTheDayService(context);
        }

        [TestCleanup]
        public void Teardown()
        {
            CloseDbConnection();
        }

        [TestMethod]
        public async Task GetWordOfTheDay_ReturnsWord()
        {
            using var context = new AppDbContext(Options);
            var wordOfTheDayService = new WordOfTheDayService(context);

            // Act
            var word = await wordOfTheDayService.GetWordOfTheDayAsync();

            // Assert
            Assert.IsNotNull(word);
        }
    }
}
