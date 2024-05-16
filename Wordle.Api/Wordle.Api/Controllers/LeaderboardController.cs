using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Services;
using Wordle.Api.Dtos;
using Wordle.Api.Models;
using Microsoft.Extensions.Logging;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LeaderboardController : ControllerBase
{
    private readonly LeaderboardService _service;
    private readonly ILogger<LeaderboardController> _logger;

    public LeaderboardController(LeaderboardService service, ILogger<LeaderboardController> logger)
    {
        _service = service;
        _logger = logger;
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
            _logger.LogError(ex, "An error occurred while getting scores");
            return StatusCode(500, new { message = "An error occurred while getting scores. Please try again later." });
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
            _logger.LogError(ex, "An error occurred while posting score");
            return StatusCode(500, new { message = "An error occurred while posting score. Please try again later." });
        }
    }
}
