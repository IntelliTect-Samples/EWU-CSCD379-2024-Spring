
namespace Wordle.Api.Tests;

[TestClass]
public class LeaderboardServiceTests
{
	[TestMethod]
	public void GetTopScores_ReturnsListOfSizeTen()
	{
		// Arrange
		LeaderboardService service = new();

		// Act
		var scores = service.GetTopScores();

		// Assert
		Assert.AreEqual(10, scores.Count);
	}

	[TestMethod]
	public void GetTopScores_ReturnsFullPlayers()
	{
		// Arrange
		LeaderboardService service = new();

		// Act
		var scores = service.GetTopScores();

		// Assert
		Assert.AreEqual(10, scores.Count);
	}
}
