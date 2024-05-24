using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Wordle.Api.Tests;

[TestClass]
public class WordControllerTests
{
	private readonly WebApplicationFactory<Program> _factory = new();

	[TestMethod]
	public async Task GetWord_ReturnsString()
	{
		// Arrange
		var client = _factory.CreateClient();

		// Act
		var response = await client.GetAsync("/word/wordoftheday");

		// Assert
		Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
	}

	[TestMethod]
	public async Task GetWord_ReturnsStringContent()
	{
		// Arrange
		var client = _factory.CreateClient();

		// Act
		var response = await client.GetAsync("/word/wordoftheday");
		var content = await response.Content.ReadAsStringAsync();

		// Assert
		Assert.AreNotEqual("Test String", content);
		Assert.IsFalse(string.IsNullOrWhiteSpace(content));
	}

	[TestMethod]
	public async Task GetWordByDate_ReturnsWord()
	{
		// Arrange
		var client = _factory.CreateClient();
		var wordOfTheDayResponse = await client.GetAsync("/word/wordoftheday");
		var wordOfTheDay = await wordOfTheDayResponse.Content.ReadAsStringAsync();
		DateOnly date = DateOnly.FromDateTime(DateTime.UtcNow.AddHours(-7));

		// Act
		var response = await client.GetAsync($"/word/wordbydate/{date.Month}/{date.Day}/{date.Year}");
		var content = await response.Content.ReadAsStringAsync();

		// Assert
		Assert.AreEqual(wordOfTheDay, content);
	}
}