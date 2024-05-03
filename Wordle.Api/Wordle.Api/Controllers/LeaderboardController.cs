using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Services;
using Wordle.Api.Requests;
using Wordle.Api.Dtos;
using System.Numerics;
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
		return await _service.GetTopScores();
	}

	[HttpPost("PostScore")]
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
