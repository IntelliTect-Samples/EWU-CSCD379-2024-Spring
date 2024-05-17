using Wordle.Api.Models;

namespace Wordle.Api.Tests;

[TestClass]
public class WordOfTheDayServiceTests : DatabaseTestBase
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
        // Arrange
        using var context = new WordleDbContext(Options);
        WordOfTheDayService service = new(context);
        DateOnly date = DateOnly.FromDateTime(DateTime.UtcNow);

        // Act
        var word = service.GetWordOfTheDay(date);

        // Assert
        Equals(word, service.GetWordOfTheDay(date));
    }
}