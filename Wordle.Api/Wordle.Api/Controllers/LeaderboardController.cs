using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Services;
using Wordle.Api.Dtos;
using Wordle.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LeaderboardController : ControllerBase
{
    private readonly WordleDbContext _context;

    public LeaderboardManagerController(WordleDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Player>>> GetTopPlayers()
    {
        var players = await _context.Players
            .OrderByDescending(p => p.AverageAttempts)
            .Take(10)
            .ToListAsync();
        return Ok(players);
    }

    [HttpPost]
    public async Task<ActionResult<Player>> PostPlayer([FromBody] Player player)
    {
        var existingPlayer = await _context.Players.FirstOrDefaultAsync(p => p.Name == player.Name);
        if (existingPlayer != null)
        {
            existingPlayer.GameCount += player.GameCount;
            double totalAttempts = existingPlayer.AverageAttempts * (existingPlayer.GameCount - 1) + player.AverageAttempts;
            existingPlayer.AverageAttempts = totalAttempts / existingPlayer.GameCount;
            
            if (player.AverageSecondsPerGame.HasValue)
            {
                double totalSeconds = existingPlayer.AverageSecondsPerGame.GetValueOrDefault() * (existingPlayer.GameCount - 1) + player.AverageSecondsPerGame.Value;
                existingPlayer.AverageSecondsPerGame = totalSeconds / existingPlayer.GameCount;
            }
        }
        else
        {
            _context.Players.Add(player);
        }

        await _context.SaveChangesAsync();
        return Ok(player);
    }
}
