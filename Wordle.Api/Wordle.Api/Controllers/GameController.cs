using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Dtos;
using Wordle.Api.Models;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class GameController(GameService gameService) : ControllerBase
{
    [HttpPost("Result")]
    public async Task<GameStatsDto> PostGame(GameDto gameDto)
    {
        Game game = await gameService.PostGameResult(gameDto);
        var stats = await gameService.GetGameStats(game);

        return stats;

    }
    
    
}