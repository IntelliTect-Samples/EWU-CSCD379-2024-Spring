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


    // TODO: Add a database to test with!
    //[TestMethod]
    //public void GetWordOfTheDay_SameWord()
    //{
    //    WordOfTheDayService service = new();
    //    var word = service.GetRandomWord();
    //    CollectionAssert.Equals(word, service.GetRandomWord());
    //}

}