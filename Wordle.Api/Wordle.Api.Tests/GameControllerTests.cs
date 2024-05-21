
using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.IdentityModel.Tokens;
using Wordle.Api.Dtos;

namespace Wordle.Api.Tests;

[TestClass]
public class GameControllerTests
{
	private readonly WebApplicationFactory<Program> _factory = new();

	[TestMethod]
	public async Task GetLastTenWords_Success()
	{
		// Arrange
		var client = _factory.CreateClient();

		// Act
		var response = await client.GetAsync("/game/lastTenWords?name=Guest");

		// Assert
		Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
	}
}
