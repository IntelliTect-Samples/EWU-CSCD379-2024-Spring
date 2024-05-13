using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Services;
using Wordle.Api.Dtos;
using Wordle.Api.Models;

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

	[HttpGet("GetScores")]
	public async Task<List<PlayerDto>> Get()
	{
		return await _service.GetTopScoresAsync();
	}

	[HttpPost("PostScore")]
	public async Task<PlayerDto> Post(PlayerDto request)
	{
		Player player = await _service.PostScoreAsync(request);
		return new PlayerDto
		{
			Name = player.Name,
			GameCount = player.GameCount,
			AverageAttempts = player.AverageAttempts
		};
	}
}
