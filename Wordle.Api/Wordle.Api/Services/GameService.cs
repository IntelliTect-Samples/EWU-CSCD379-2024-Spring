using Microsoft.EntityFrameworkCore;
using Wordle.Api.Dtos;
using Wordle.Api.Models;

namespace Wordle.Api.Services;
public class GameService
{
    public WordleDbContext Db { get; set; }

    public GameService(WordleDbContext db)
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


  public async Task<GameStatsDto> SingleWordStats(DateTime date)
  {
    DateOnly dateOfDay = DateOnly.FromDateTime(date);

    WordOfTheDay? word = await Db.WordsOfTheDays
      .Include(word => word.Games)
      .FirstOrDefaultAsync(word => word.Date == dateOfDay);

    IEnumerable<Game> gamesOfWord;
    GameStatsDto stats;

    if (word is not null && word.Games.Count != 0)
    {
      gamesOfWord = word.Games;

      stats = new()
      {
        Date = word!.Date,
        AverageGuesses = gamesOfWord.Average(g => g.Attempts),
        TotalTimesPlayed = gamesOfWord.Count(),
        TotalWins = gamesOfWord.Count(w => w.IsWin),
        AverageSeconds = 0//gamesOfWord.Average(s => s.Seconds)
      };
    }
    else 
    {
      stats = new()
      {
        Date = dateOfDay,
        AverageGuesses = 0,
        TotalTimesPlayed = 0,
        TotalWins = 0,
        AverageSeconds = 0
      };
    }
    return stats;
  }

  public async Task<List<GameStatsDto>> LastTenWordStats(DateTime date)
  {
    List<GameStatsDto> lastTenDayGames = [];

    for(int i = 0; i < 10; i++){
        lastTenDayGames.Add(await SingleWordStats(date.AddDays(-i)));
      }
      return lastTenDayGames;
    }
}


public class AllWordStats()
{
    public required string Word { get; set; }

    public double AverageGuesses { get; set; }
}
