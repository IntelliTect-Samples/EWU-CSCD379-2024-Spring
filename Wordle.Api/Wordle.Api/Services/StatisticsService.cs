using Microsoft.EntityFrameworkCore;
using Wordle.Api.Dtos;
using Wordle.Api.Models;

namespace Wordle.Api.Services;
public class StatisticsService(WordleDbContext db)
{
    public WordleDbContext Db { get; set; } = db;

    public async Task<GameStatsDto> GetAllGames()
    {
        IEnumerable<Game> games = await Db.Games.ToListAsync() ?? [];
        GameStatsDto stats;

        stats = new()
        {
            AverageGuesses = games.Average(g => g.Attempts),
            TotalTimesPlayed = games.Count(),
            TotalWins = games.Count(g => g.IsWin),
            AverageSeconds = games.Average(w => w.Seconds),
            Usernames = [.. games.Select(g => g.Name).Where(name => !string.IsNullOrEmpty(name))]

        };

        return stats;
    }

}

