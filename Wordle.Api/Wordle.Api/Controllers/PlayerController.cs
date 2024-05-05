using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Models;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController(PlayerService playerService) : ControllerBase
{
    [HttpGet("TopPlayers")]
    public async Task<Player[]> GetTopPlayers(int numberOfPlayers = 10)
    {
        return await playerService.GetTopPlayers(numberOfPlayers);
    }
    
    [HttpPost("AddPlayer")]
    public async Task<Player> AddPlayer(Player player)
    {
        await playerService.AddPlayer(player);
        return player;
    }
}