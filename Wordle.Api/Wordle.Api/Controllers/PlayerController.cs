using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class PlayerController(PlayerService playerService) : ControllerBase
{
    [HttpGet("Leaderboard")]
    public async Task<List<PlayerDto>> GetTopScores(int num)
    {
        return await playerService.GetTopScores(num);
    }
    [HttpPost("UpdateScore")]
    public async Task<bool> UpdateScore(ScoreDto score)
    {
        return await playerService.UpdateScore(score);
    }
}
