using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Services;
using Wordle.Api.Requests;
using Wordle.Api.Dtos;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LeaderboardController : ControllerBase
{
	private readonly LeaderboardService _service;
	public LeaderboardController(LeaderboardService service)
	{
		_service = service;
	}
	
	[HttpGet(Name = "GetScores")]
	public List<Player> Get()
	{
		return _service.GetTopScores();
	}

	[HttpPost(Name = "PostScore")]
	public async Task<PlayerDto> Post(PlayerRequest request)
	{
		Player player = await _service.PostScore(request);
		return new PlayerDto
		{
			Name = player.Name,
			GameCount = player.GameCount,
			AverageAttempts = player.AverageAttempts
		};
	}
}
