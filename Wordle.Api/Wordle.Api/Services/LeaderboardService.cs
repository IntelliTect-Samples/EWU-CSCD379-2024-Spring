using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Models;

namespace Wordle.Api.Services
{
    public class LeaderboardService
    {
        private readonly WordleDbContext _context;

        public LeaderboardService(WordleDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlayerDto>> GetTopTenPlayers()
        {
            return await _context.Players
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
                .ToListAsync();
        }

        public async Task SavePlayerScore(Player player)
        {
            var existingPlayer = await _context.Players.FirstOrDefaultAsync(p => p.Name == player.Name);

            if (existingPlayer == null)
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
            else
            {
                existingPlayer.GameCount++;
                existingPlayer.AverageAttempts = (player.AverageAttempts + existingPlayer.AverageAttempts * (existingPlayer.GameCount - 1)) / existingPlayer.GameCount;
                existingPlayer.AverageSecondsPerGame = (player.AverageSecondsPerGame + existingPlayer.AverageSecondsPerGame * (existingPlayer.GameCount - 1)) / existingPlayer.GameCount;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<DailyStatsDto> GetDailyStatsAsync(DateOnly date)
        {
            var gamesOnDate = await _context.Games
                .Where(g => g.DateAttempted.Date == date.ToDateTime(new TimeOnly()).Date)
                .ToListAsync();

            if (!gamesOnDate.Any())
            {
                return new DailyStatsDto
                {
                    NumberOfPlays = 0,
                    AverageScore = 0,
                    AverageSecondsPerGame = 0,
                    UserHasPlayed = false // Implement logic to check if the user has played
                };
            }

            var numberOfPlays = gamesOnDate.Count;
            var averageScore = gamesOnDate.Average(g => g.Attempts);
             var averageSecondsPerGame = gamesOnDate.Average(g => g.WordOfTheDayId.HasValue && g.WordOfTheDay != null ? g.WordOfTheDay.WordOfTheDayId : 0);


            return new DailyStatsDto
            {
                NumberOfPlays = numberOfPlays,
                AverageScore = averageScore,
                AverageSecondsPerGame = averageSecondsPerGame,
                UserHasPlayed = false
            };
        }
    }
}
