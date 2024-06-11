using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wordle.Api.Services
{
    public class LeaderboardService
    {
        private readonly WordleDbContext _context;
        private static readonly object _lock = new object();

        public LeaderboardService(WordleDbContext context)
        {
            _context = context;
        }

        public async Task SavePlayerScore(Player player)
        {
            var existingPlayer = await _context.Players.FirstOrDefaultAsync(p => p.Name == player.Name);

            if (existingPlayer == null)
            {
                lock (_lock)
                {
                    existingPlayer = new Player
                    {
                        Name = player.Name,
                        GameCount = 1,
                        AverageAttempts = player.AverageAttempts,
                        AverageSecondsPerGame = player.AverageSecondsPerGame
                    };
                    _context.Players.Add(existingPlayer);
                }
            }
            else
            {
                existingPlayer.GameCount++;
                existingPlayer.AverageAttempts = (player.AverageAttempts + existingPlayer.AverageAttempts * (existingPlayer.GameCount - 1)) / existingPlayer.GameCount;
                existingPlayer.AverageSecondsPerGame = (player.AverageSecondsPerGame + existingPlayer.AverageSecondsPerGame * (existingPlayer.GameCount - 1)) / existingPlayer.GameCount;
            }

            await _context.SaveChangesAsync();
        }

        public IEnumerable<PlayerDto> GetTopTenPlayers()
        {
            return _context.Players
                .OrderBy(player => player.AverageAttempts)
                .ThenBy(player => player.GameCount)
                .ThenBy(player => player.AverageSecondsPerGame)
                .Select(player => new PlayerDto
                {
                    Name = player.Name,
                    GameCount = player.GameCount,
                    AverageAttempts = player.AverageAttempts,
                    AverageSecondsPerGame = player.AverageSecondsPerGame
                })
                .Take(10)
                .ToList();
        }
    }
}
