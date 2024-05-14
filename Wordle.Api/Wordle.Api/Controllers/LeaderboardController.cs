using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Services;
using Wordle.Api.Dtos;
using Wordle.Api.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LeaderboardController : ControllerBase
{
    private readonly LeaderboardService _service;

    public LeaderboardController(LeaderboardService service)
    {
        _service = service;
    }

    [HttpGet("GetScores")]
    public async Task<ActionResult<List<PlayerDto>>> Get()
    {
        try
        {
            var scores = await _service.GetTopScoresAsync();
            return Ok(scores);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpPost("PostScore")]
    public async Task<ActionResult<PlayerDto>> Post(PlayerDto request)
    {
        try
        {
            Player player = await _service.PostScoreAsync(request);
            return Ok(new PlayerDto
            {
                Name = player.Name,
                GameCount = player.GameCount,
                AverageAttempts = player.AverageAttempts
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
