using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wordle.Api.Dtos;
using Wordle.Api.Models;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaderboardController : ControllerBase
    {
        private readonly LeaderboardService _leaderboardService;

        public LeaderboardController(LeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
        }

        [HttpGet("GetScores")]
        public async Task<ActionResult<IEnumerable<PlayerDto>>> GetScores()
        {
            var scores = await _leaderboardService.GetTopTenPlayers();
            return Ok(scores);
        }

        [HttpPost("PostScore")]
        public async Task<ActionResult> PostScore(Player player)
        {
            await _leaderboardService.SavePlayerScore(player);
            return Ok();
        }

        [HttpGet("GetDailyStats/{date}")]
        public async Task<ActionResult<DailyStatsDto>> GetDailyStats(string date)
        {
            if (!DateOnly.TryParse(date, out var parsedDate))
            {
                return BadRequest("Invalid date format.");
            }

            var stats = await _leaderboardService.GetDailyStatsAsync(parsedDate);
            return Ok(stats);
        }
    }
}
