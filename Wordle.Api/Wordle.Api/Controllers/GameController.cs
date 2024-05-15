using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Dtos;
using Wordle.Api.Models;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private GameService _service { get; set; }

    public GameController(GameService service)
    {
        _service = service;
    }

    [HttpPost("GameWordOfTheDay")]
    public async Task<bool> PostGame(GameDto gameDto)
    {
        return await _service.AddGame(gameDto);
    }

    [HttpGet("DailyWordStatistics")]
    public async Task<List<WordGameStatisticDto>> GetDailyWordStatistics(string name)
    {
        return await _service.GetDailyWordStatistics(name);
    }
}
