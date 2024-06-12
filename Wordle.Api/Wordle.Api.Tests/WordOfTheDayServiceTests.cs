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
        private WordOfTheDayService _wordOfTheDayService;
        private WordleDbContext _context;

        [TestInitialize]
        public async Task Setup()
        {
            InitializeDb();
            _context = new WordleDbContext(Options);
            await Seeder.Seed(_context);
            _wordOfTheDayService = new WordOfTheDayService(_context);
        }

        [TestCleanup]
        public void Teardown()
        {
            CloseDbConnection();
            _context.Dispose();
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
