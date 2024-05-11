using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Dtos;
using Wordle.Api.Models;
using Wordle.Api.Services;


namespace Wordle.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController(WordStatisticsService WordStatisticsService) : ControllerBase
{

    [HttpGet("word/{word}")]
    public async Task<IEnumerable<Game>> GetWordStatistics(string word){
        return await WordStatisticsService.GetStatistics(word);
    }


}

