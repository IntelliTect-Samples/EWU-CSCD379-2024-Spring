using Microsoft.EntityFrameworkCore;
using Wordle.Api.Dtos;
using Wordle.Api.Models;

namespace Wordle.Api.Services;

public class WordStatisticsService(WordleDbContext Db)
{
    private static object _lock = new();
    public WordleDbContext Db { get; set; } = Db;


    public async Task<WordStatsDto> GetStatistics()
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        WordOfTheDay? wordOfTheDay = await Db.WordsOfTheDays
            .Include(wotd => wotd.Games)
            .FirstOrDefaultAsync(wordOfTheDay => wordOfTheDay.Date == today);
        Console.WriteLine(wordOfTheDay);

        WordStatsDto wordStatsDto;

        if(wordOfTheDay is not null)
        {
            wordStatsDto = new WordStatsDto()
            {
                Date = today,
                AverageAttempts = wordOfTheDay.Games.Average(game => game.Attempts),
                TotalGamesPlayed = wordOfTheDay.Games.Count(),
                NumberOfWins = wordOfTheDay.Games.Select(game => game.IsWin == true).Count(),
            };
        }
        else
        {
            wordStatsDto = null;
        }


        return wordStatsDto;


    }
}

