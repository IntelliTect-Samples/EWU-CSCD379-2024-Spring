using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Dtos;
using Wordle.Api.Models;
using Wordle.Api.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public ActionResult<IEnumerable<PlayerDto>> GetScores()
        {
            return Ok(_leaderboardService.GetTopTenPlayers());
        }

        [HttpPost("PostScore")]
        public async Task<ActionResult> PostScore(Player player)
        {
            await _leaderboardService.SavePlayerScore(player);
            return Ok();
        }
    }
}
