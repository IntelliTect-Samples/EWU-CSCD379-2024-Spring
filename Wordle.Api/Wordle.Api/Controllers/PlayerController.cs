using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Dtos;
using Wordle.Api.Models;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController(PlayerServices PlayerService) : ControllerBase
{
    [HttpGet("Leaderboard")]
    public IEnumerable<PlayerDto> GetLeaderboard()
    {
        return PlayerService.TopTenPlayers();
    }

    [HttpPost("SaveScore")]
    public async Task SaveScores(Score score)
    {
        await PlayerService.SavePlayer(score);
    }

}

