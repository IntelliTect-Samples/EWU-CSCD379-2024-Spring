using Microsoft.EntityFrameworkCore;
using System;
using Wordle.Api.Dtos;
using Wordle.Api.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Wordle.Api.Services;

public class WordStatisticsService(WordleDbContext Db)
{
    public WordleDbContext Db { get; set; } = Db;


    public async Task<List<WordStatsDto>> GetStatisticsRange(int numDays)
    {
        List<WordStatsDto> statistics = [];
        DateTime endDate = DateTime.Now.AddDays(-numDays);
        for (DateTime date = DateTime.Now; date >= endDate; date = date.AddDays(-1))
        {
            WordStatsDto stats = await GetStatistics(date);
            statistics.Add(stats);
        }

        return statistics;
    }

    public async Task<WordStatsDto> GetStatistics(DateTime date)
    {
        var dateOnly = DateOnly.FromDateTime(date);

        WordOfTheDay? wordOfTheDay = await Db.WordsOfTheDays
            .Include(wotd => wotd.Games)
            .Include(wotd => wotd.Word)
            .FirstOrDefaultAsync(wordOfTheDay => wordOfTheDay.Date == dateOnly);

        WordStatsDto wordStatsDto;

        if(wordOfTheDay is not null && wordOfTheDay.Games.Count != 0)
        {
            wordStatsDto = new WordStatsDto()
            {
                Date = dateOnly,
                AverageAttempts = wordOfTheDay.Games.Average(game => game.Attempts),
                TotalGamesPlayed = wordOfTheDay.Games.Count,
                NumberOfWins = wordOfTheDay.Games.Select(game => game.IsWin == true).Count(),
                Games = wordOfTheDay.Games
                .Select(game => new GameDto()
                {

                    Word = wordOfTheDay.Word.Text,
                    Attempts = game.Attempts,
                    IsWin = game.IsWin
                }).ToList()
             };
        }
        else
        {
            wordStatsDto = new WordStatsDto()
            {
                Date = dateOnly,
                AverageAttempts = 0,
                TotalGamesPlayed = 0,
                NumberOfWins = 0,
            };
        }

        return wordStatsDto;

    }
}

