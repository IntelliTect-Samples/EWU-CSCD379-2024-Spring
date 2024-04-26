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
        var response = await client.GetAsync("/word");

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [TestMethod]
    public async Task GetWord_ReturnsStringContent()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/word");
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.AreNotEqual("Test String", content);
        Assert.IsFalse(string.IsNullOrWhiteSpace(content));
    }
}
