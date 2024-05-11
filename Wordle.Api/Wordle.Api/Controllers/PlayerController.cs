using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Models;
using Wordle.Api.Services;
using Wordle.Api.DTOS;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController(PlayerService playerService) : ControllerBase
{

    [HttpGet("Player")]
    public async Task<Player?> GetPlayer(string playerName = "Guest")
    {
        return await playerService.GetPlayer(playerName) ?? null;
    }
    
    [HttpGet("TopPlayers")]
    public async Task<Player[]> GetTopPlayers(int numberOfPlayers = 10)
    {
        return await playerService.GetTopPlayers(numberOfPlayers);
    }
    
    [HttpPost("AddPlayer")]
	public async Task<PlayerDTO?> Post(PlayerDTO playerDto)
	{
		await playerService.AddPlayer(playerDto);
        return playerDto;
	}
}