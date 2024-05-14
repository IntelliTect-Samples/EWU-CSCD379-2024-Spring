using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Wordle.Api.Services;

public class LeaderboardService
{
    private readonly AppDbContext _context;

    public LeaderboardService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PlayerDto>> GetTopScoresAsync()
    {
        return await _context.Players
            .OrderBy(player => player.AverageAttempts)
            .Take(10)
            .Select(player => new PlayerDto
            {
                Name = player.Name,
                GameCount = player.GameCount,
                AverageAttempts = player.AverageAttempts
            }).ToListAsync();
    }

    public async Task<Player> PostScoreAsync(PlayerDto request)
    {
        var foundPlayer = await _context.Players.FirstOrDefaultAsync(player => player.Name.Equals(request.Name));

        if (foundPlayer != null)
        {
            double attempts = foundPlayer.AverageAttempts * foundPlayer.GameCount + request.AverageAttempts;
            foundPlayer.GameCount += request.GameCount;
            foundPlayer.AverageAttempts = attempts / foundPlayer.GameCount;
            _context.Players.Update(foundPlayer);
        }
        else
        {
            foundPlayer = new Player
            {
                Name = request.Name,
                GameCount = request.GameCount,
                AverageAttempts = request.AverageAttempts
            };
            await _context.Players.AddAsync(foundPlayer);
        }

        await _context.SaveChangesAsync();
        return foundPlayer;
    }
}
