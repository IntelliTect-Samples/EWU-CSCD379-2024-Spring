using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Services;
using Wordle.Api.Dtos;
using Wordle.Api.Models;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LeaderboardController : ControllerBase
{
	private readonly ScoreService _scoreService;
	public LeaderboardController(ScoreService scoreService)
	{
		_scoreService = scoreService;
	}

	[HttpGet("GetTopScores")]
	public async Task<List<PlayerDTO>> Get()
	{
		return await _scoreService.GetTopScoresAsync();
	}

	[HttpPost("AddScore")]
	public async Task<PlayerDTO> Post(PlayerDTO request)
	{
		Player player = await _scoreService.PostScoreAsync(request);
		return new PlayerDTO
		{
			Name = player.Name,
			GameCount = player.GameCount,
			AverageAttempts = player.AverageAttempts
            AverageSecondsPerGame = player.AverageSecondsPerGame;
		};
	}
}