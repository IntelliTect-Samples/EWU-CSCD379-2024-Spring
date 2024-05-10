using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Models;
using Wordle.Api.Services;
using Wordle.Api.Dtos;

namespace Wordle.Api.Controllers;

  [ApiController]
  [Route("[controller]")]
  public class LeaderboardController : ControllerBase 
  {
    private readonly WordleService _service;

    public LeaderboardController(WordleService wordleService)
    {
      _service = wordleService;
    }

    [HttpGet("top10")]
    public async Task<Player[]> GetTop10Scores()
    {
      return await _service.GetTop10Scores();
    }

    [HttpPost]
    public async Task<PlayerDTO> PostScore(PlayerDTO player)
    {
      Player postedPlayer = await _service.AddOrUpdatePlayer(player);
      return new PlayerDTO{
        Name = player.Name,
        GameCount = player.GameCount,
        AverageAttempts = player.AverageAttempts,
        AverageSecondsPerGame = player.AverageSecondsPerGame
      };
    }
  }

