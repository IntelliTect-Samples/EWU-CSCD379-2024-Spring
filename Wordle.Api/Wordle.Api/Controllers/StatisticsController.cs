using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Dtos;
using Wordle.Api.Models;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class StatisticsController(StatisticsService StatisticsService) : ControllerBase
{
    public StatisticsService StatisticsService { get; set; } = StatisticsService;


    [HttpPost("AllGamesStats")]
    public async Task<GameStatsDto> GetAllGameStats()
    {
        var stats = await StatisticsService.GetAllGames();

        return stats;
    }

}
