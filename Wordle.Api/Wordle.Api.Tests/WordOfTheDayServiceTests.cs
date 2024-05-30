using Wordle.Api.Models;
using Wordle.Api.Services;

namespace Wordle.Api.Tests
{
    [TestClass]
    public class WordOfTheDayServiceTests :DatabaseTestBase
    {
        [TestMethod]
        public void LoadWordList_SuccessfullyGetsWords()
        {
            CollectionAssert.AllItemsAreNotNull(WordOfTheDayService.WordList());
        }

        [TestMethod]
        public void GetWordOfTheDay_ReturnsString()
        {
            CollectionAssert.Contains(WordOfTheDayService.WordList(), "yules");
        }

        [TestMethod]
        public void GetWordOfTheDay_SameWord()
        {
            using var context = new WordleDbContext(Options);
            WordOfTheDayService service = new(context);

            var date = DateOnly.FromDateTime(DateTime.UtcNow);
            
            var word = service.GetWordOfTheDay(date);
            Equals(word, service.GetWordOfTheDay(date));
        }
    }
}