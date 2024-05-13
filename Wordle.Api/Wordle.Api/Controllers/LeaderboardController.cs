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

    // Correcting the constructor name to match the class name
    public LeaderboardController(WordleDbContext context)
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
    public async Data Task<ActionResult<Player>> PostPlayer([FromBody] Player player)
    {
        var existingPlayer = await _context.Players.FirstOrDefaultAsync(p => p.Name == player.Name);
        if (existingPlayer != null)
        {
            existingPlayer.GameCount += player.GameCount;
            existingPlayer.AverageAttempts = ((existingPlayer.AverageAttempts * (existingPlayer.GameCount - 1)) + player.AverageAttempts) / existingPlayer.GameCount;
            
            if (player.AverageSecondsPerGame.HasValue)
                existingPlayer.AverageSecondsPerGame = ((existingPlayer.AverageSecondsPerGame.GetValueOrDefault() * (existingPlayer.GameCount - 1)) + player.AverageSecondsPerGame.Value) / existingPlayer.GameCount;
        }
        else
        {
            _context.Players.Add(player);
        }

        await _context.SaveChangesAsync();
        return Ok(player);
    }
}
