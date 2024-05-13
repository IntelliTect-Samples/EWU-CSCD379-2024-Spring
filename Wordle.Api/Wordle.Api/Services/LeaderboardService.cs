using Microsoft.EntityFrameworkCore;
using Wordle.Api.Services;
using Wordle.Api.Dtos;
using Wordle.Api.Models;

namespace Wordle.Api.Services;

public class LeaderboardService
{
    private readonly WordleDbContext _context;
    private static readonly object _changingPlayerLock = new();
    private static readonly object _addingPlayerLock = new();

    public LeaderboardService(WordleDbContext context)
    {
        _context = context;
    }

    public async Task<List<PlayerDto>> GetTopScoresAsync()
    {
        return await _context.Players
            .OrderBy(p => p.AverageAttempts)
            .Take(10)
            .Select(p => new PlayerDto
            {
                Name = p.Name,
                GameCount = p.GameCount,
                AverageAttempts = p.AverageAttempts
            }).ToListAsync();
    }

    public async Task<Player> PostScoreAsync(PlayerDto request)
    {
        var foundPlayer = await _context.Players.FirstOrDefaultAsync(p => p.Name == request.Name);
        if (foundComposer != null)
        {
            lock (_changingPlayerLock)
            {
                double attempts = foundPlayer.AverageAttempts * foundPlayer.GameCount + request.AverageAttempts;
                foundPlayer.GameCount += request.GameGameCount;
                foundPlayer.AverageAttempts = attempts / foundPlayer.GameCount;
                await _context.SaveChangesAsync();
                return foundPlayer;
            }
        }
        else
        {
            lock (_addingPlayerLock)
            {
                var newPlayer = new Player
                {
                    Name = request.Name,
                    AverageAttempts = request.AverageAttempts,
                    GameCount = request.GameCount,
                };
                _context.Players.Add(newPlayer);
                await _context.SaveChangesAsync();
                return newPlayer;
            }
        }
    }
}
