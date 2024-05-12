using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Dtos;
using Wordle.Api.Models;
using Wordle.Api.Services;


namespace Wordle.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController(WordStatisticsService WordStatisticsService) : ControllerBase
{

    [HttpGet("GetWordStats")]
    public async Task<List<WordStatsDto>> GetWordStatistics(int numDays){
        return await WordStatisticsService.GetStatisticsRange(numDays);
    }
}

