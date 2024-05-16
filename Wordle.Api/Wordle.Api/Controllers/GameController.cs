using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Dtos;
using Wordle.Api.Models;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    public GameService GameService { get; set; }

    public GameController(GameService gameService)
    {
        GameService = gameService;
    }

    [HttpPost("Result")]
    public async Task<GameStatsDto> PostGame(GameDto gameDto)
    {
        Game game = await GameService.PostGameResult(gameDto);
        var stats = await GameService.GetGameStats(game);

        return stats;
    }

    [HttpGet("LastTenWords")]
    public async Task<List<WordStatsDto>> GetLastTenWords() {
        return await GameService.GetLastTenWordStatsDtos();
    }
}
