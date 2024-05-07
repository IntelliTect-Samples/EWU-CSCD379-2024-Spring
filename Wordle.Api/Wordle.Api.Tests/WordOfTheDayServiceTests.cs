using Wordle.Api.Models;

namespace Wordle.Api.Tests;

[TestClass]
public class WordOfTheDayServiceTests : DatabaseTestBase
{
    [TestMethod]
    public void LoadWordList_SuccessfullyGetsWords()
    {
        CollectionAssert.AllItemsAreNotNull(WordOfTheDayService.LoadWordList());
    }

    [TestMethod]
    public void GetWordOfTheDay_ReturnsString()
    {
        CollectionAssert.Contains(WordOfTheDayService.LoadWordList(), "yules");
    }


    // TODO: Add a database to test with!
    [TestMethod]
    public void GetWordOfTheDay_SameWord()
    {
        // Arrange
        using var context = new WordleDbContext(Options);
        WordOfTheDayService service = new(context);

        // Act
        var word = service.GetRandomWord();

        // Assert
        Equals(word, service.GetRandomWord());
    }
}