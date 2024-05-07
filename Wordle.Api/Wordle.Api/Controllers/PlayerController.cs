using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Models;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController(PlayerServices PlayerService) : ControllerBase
{
    [HttpGet("Leaderboard")]
    public IEnumerable<Player> GetLeaderboard()
    {
        return PlayerService.TopTenPlayers();
    }

    [HttpPost("SaveScore")]
    public async Task SaveScores(string name, int attempts)
    {
        await PlayerService.AddPlayer(name, attempts);
    }

}

