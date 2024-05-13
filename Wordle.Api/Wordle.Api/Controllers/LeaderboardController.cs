using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Models;
using Wordle.Api.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LeaderboardController : ControllerBase
{
    private readonly WordleDbContext _context;

    public LeaderboardController(WordleDbContext context)
    {
        _context = context;
    }

    // Get top 10 scores
    [HttpGet]
    public async Task<IActionResult> GetTopScores()
    {
        var topScores = await _context.Players
            .OrderByDescending(p => p.AverageAttempts)
            .Take(10)
            .ToListAsync();
        return Ok(topScores);
    }

    // Post a score
    [HttpPost]
    public async Task<IActionResult> PostScore([FromBody] Player player)
    {
        var existingPlayer = await _context.Players
            .FirstOrDefaultAsync(p => p.Name == player.Name);

        if (existingStack != null)
        {
            existingPlayer.GameCount += 1;
            existingPlayer.AverageAttempts = (existingPlayer.AverageAttempts * (existingPlayer.GameCount - 1) + player.AverageAttempts) / existingPlayer.GameCount;
            // Optional: update AverageSecondsPerGame if included
        }
        else
        {
            _context.Players.Add(player);
        }

        await _context.SaveChangesAsync();
        return Ok(player);
    }
}
