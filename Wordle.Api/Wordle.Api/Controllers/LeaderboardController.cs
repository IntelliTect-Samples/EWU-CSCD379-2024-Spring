using Microsoft.AspNetCore.Mvc;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LeaderboardController : ControllerBase
{
	[HttpGet(Name = "GetScores")]
	public List<string> Get()
	{
		return new List<string> {
			"1",
			"2",
			"3",
			"4",
			"5",
			"6",
			"7",
			"8",
			"9",
			"10"
		};
	}
}
