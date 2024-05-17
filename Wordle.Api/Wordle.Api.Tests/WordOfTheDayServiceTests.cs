namespace Wordle.Api.Tests;

[TestClass]
public class WordOfTheDayServiceTests
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
}