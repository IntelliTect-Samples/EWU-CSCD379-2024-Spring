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

	[HttpGet(Name = "GetScores")]
	public List<PlayerDto> Get()
	{
		return _service.GetTopScores();
		// for testing before setting up azure db
		//return [new PlayerDto() {
		//	Name = "Joshua",
		//	GameCount = 1,
		//	AverageAttempts = 0
		//}, new PlayerDto() {
		//	Name = "Jimbob",
		//	GameCount = 10000,
		//	AverageAttempts = 6
		//}, new PlayerDto() {
		//	Name = "Jimbob Jr.",
		//	GameCount = 5,
		//	AverageAttempts = 4
		//}];
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
	////this should work
	//[HttpGet("GetTopTenScores")]
	//public async Task<IEnumerable<Player>> GetTopTenScores()
	//{
	//	return await _service.GetTopScores();
	//}
}
