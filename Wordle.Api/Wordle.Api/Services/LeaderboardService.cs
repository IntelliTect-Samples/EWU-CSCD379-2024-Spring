using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Models;
using Microsoft.Extensions.Logging;

namespace Wordle.Api.Services;

public class LeaderboardService
{
    private readonly AppDbContext _context;
    private readonly ILogger<LeaderboardService> _logger;

    public LeaderboardService(AppDbContext context, ILogger<LeaderboardService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<PlayerDto>> GetTopScoresAsync()
    {
        try
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
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting top scores");
            throw;
        }
    }

    public async Task<Player> PostScoreAsync(PlayerDto request)
    {
        try
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
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while posting score");
            throw;
        }
    }
}
