using Wordle.Api.Data;
using Wordle.Api.Services;

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
		using var context = new AppDbContext(Options);
		WordOfTheDayService service = new(context);
		var word = service.GetRandomWord();
		CollectionAssert.Equals(word, service.GetRandomWord());
	}

}