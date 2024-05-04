
using System.Net;
using System.Net.Http.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Wordle.Api.Dtos;

namespace Wordle.Api.Tests;

[TestClass]
public class LeaderboardControllerTests
{
	private readonly WebApplicationFactory<Program> _factory = new();

	// Commenting out
	// TODO: Return and complete implementation
	//[TestMethod]
	//public async Task PostScore_ValidInput_ReturnsPlayerDto()
	//{
	//	// Arrange
	//	var client = _factory.CreateClient();
	//	var request = DatabaseTestBase.Requests.First();
	//	var stringContent = new StringContent(request.ToString());
	//	Console.WriteLine(stringContent.ToString());


	//	// Act
	//	var response = await client.PostAsync("/leaderboard/postscore", stringContent);

	//	// Assert
	//	var content = await response.Content.ReadFromJsonAsync<PlayerDto>();
	//	//Assert.AreEqual<PlayerDto>(request, content);
	//}

	[TestMethod]
	public async Task GetScores_TenScoresPosted_ReturnsListSizeTen()
	{
		// Arrange
		var client = _factory.CreateClient();
		foreach (PlayerDto dto in DatabaseTestBase.Requests)
		{
			var stringContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
			var response1 = await client.PostAsync("/leaderboard/postscore", stringContent);
			Assert.AreEqual(HttpStatusCode.OK, response1.StatusCode);
		}

		// Act
		var response = await client.GetAsync("/leaderboard/GetScores");
		var content = await response.Content.ReadFromJsonAsync<List<PlayerDto>>();

		// Assert
		Assert.IsNotNull(content);
		Assert.AreEqual(10, content.Count);
	}
}