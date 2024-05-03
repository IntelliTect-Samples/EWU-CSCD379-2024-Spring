
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Wordle.Api.Dtos;

namespace Wordle.Api.Tests;

[TestClass]
public class LeaderboardControllerTests
{
	private readonly WebApplicationFactory<Program> _factory = new();

	//[TestMethod]
	//public async Task GetScores_Something_ReturnsListSizeTen()
	//{
	//	// Arrange
	//	var client = _factory.CreateClient();

	//	// Act
	//	var response = await client.GetAsync("/leaderboard");
	//	var content = await response.Content.ReadFromJsonAsync<List<PlayerDto>>();

	//	// Assert
	//	Assert.IsNotNull(content);
	//	Assert.AreEqual(3, content.Count);
	//}
}