using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Models;

namespace Wordle.Api.Services;
public class GameService
{
    public AppDbContext Db { get; set; }

    public GameService(AppDbContext db)
    {
        Db = db;
    }

    public async Task<Game> PostGameResult(GameDto gameDto)
    {
        // Get todays date
        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        // Get all the words that match our game word and load their WOTDs
        var word = Db.Words
        .Include(word => word.WordsOfTheDays)
            .Where(word => word.Text == gameDto.Word)
            .First();

        // Create a new game object to save to the DB
        Game game = new()
        {
            Attempts = gameDto.Attempts,
            IsWin = gameDto.IsWin,
            // Attempt to find the WOTD that best matches todays date
            WordOfTheDay = word.WordsOfTheDays
                .OrderByDescending(wotd => wotd.Date)
                .FirstOrDefault(wotd => wotd.Date < today.AddDays(-1)),
            Word = word
        };

        Db.Games.Add(game);
        await Db.SaveChangesAsync();
        return game;
    }

    public async Task<GameStatsDto> GetGameStats(Game game)
    {
        var gamesForWord = Db.Games.Where(g => g.WordId == game.WordId);

        GameStatsDto stats = new()
        {
            Word = game.Word!.Text,
            AverageGuesses = await gamesForWord.AverageAsync(g => g.Attempts),
            TotalTimesPlayed = await gamesForWord.CountAsync(),
            TotalWins = await gamesForWord.CountAsync(g => g.IsWin)
        };

        return stats;
    }

    public IQueryable<AllWordStats> StatsForAllWords()
    {
        IQueryable<AllWordStats> result = Db.Games
            .Include(g => g.Word)
            .GroupBy(g => g.Word!.Text)
            .Select(g => new AllWordStats()
            {
                Word = g.Key,
                AverageGuesses = g.Average(x => x.Attempts)
            });

        return result;
    }
}

public class AllWordStats()
{
    public required string Word { get; set; }

    public double AverageGuesses { get; set; }
}
