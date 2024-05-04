using System.Linq;
using Microsoft.AspNetCore.Mvc.Testing;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Tests;

[TestClass]
public class LeaderboardServiceTests : DatabaseTestBase
{
	private readonly WebApplicationFactory<Program> _factory = new();
	private LeaderboardService _service = null!;

	[TestInitialize]
	public async Task Init()
	{
		var context = new AppDbContext(Options);
		_service = new(context);
		foreach (PlayerDto request in Requests)
		{
			await _service.PostScoreAsync(request);
		}
	}

	[TestMethod]
	public async Task GetTopScores_ReturnsListOfSizeTen()
	{
		// Arrange

		// Act
		var scores = await _service.GetTopScoresAsync();

		// Assert
		Assert.AreEqual(10, scores.Count);
	}

	[TestMethod]
	public async Task GetTopScoresAsync_SuccessfullyGetsWords()
	{
		// Arrange

		// Act
		var scores = await _service.GetTopScoresAsync();

		// Assert
		CollectionAssert.AllItemsAreNotNull(scores);
	}

	[TestMethod]
	public async Task GetWordOfTheDay_ReturnsString()
	{
		// Arrange

		// Act
		var scores = await _service.GetTopScoresAsync();

		// Assert
		CollectionAssert.Contains(scores, new PlayerDto { Name = "Jimbob Sr III", AverageAttempts = 2, GameCount = 1 });
	}

}
