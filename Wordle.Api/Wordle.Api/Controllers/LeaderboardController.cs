using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LeaderboardController : ControllerBase
{
	[HttpGet(Name = "GetScores")]
	public List<string> Get()
	{
		var service = new LeaderboardService();

		return service.GetTopScores();
	}
}
