using Microsoft.EntityFrameworkCore;
using Wordle.Api.Migrations;
using Wordle.Api.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Wordle.Api.Services;

public class WordStatisticsService(WordleDbContext Db)
{
    private static object _lock = new();
    public WordleDbContext Db { get; set; } = Db;


    public async Task<IEnumerable<Game>> GetStatistics(string word)
    {
        IEnumerable<Game> wordOfTheDayGames = Db.Games
            .Where(game => game.Word.Text == word);

        return wordOfTheDayGames;


    }
}

