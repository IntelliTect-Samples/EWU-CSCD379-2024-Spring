using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Wordle.Api.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Wordle.Api.Services;

public class LeaderboardService
{
    //private readonly List<string> words = LoadWordList();
    private static object _lock = new();

    public WordleDbContext Db { get; set; }

    public LeaderboardService(WordleDbContext db)
    {
        Db = db;
    }

    public async Task<string[][]> GetTopTenScores()
    {
        string[][] scores = new string[10][];


        List<Player> players = await Db.Players.OrderByDescending(player => player.AverageAttempts).ToListAsync();

        for (int j = 0; j < players.Count; j++)
        {
            scores[j] = new string[3];
        }

        for (int i = 0; i < players.Count && i < 10; i++)
        {
            scores[i][0] = players[i].Name;
            scores[i][1] = "" + players[i].AverageAttempts;
            scores[i][2] = "" + players[i].GameCount;
        }

        return scores;
    }

    public async Task<bool> UpdateScore(string playerName, int attempts, int time)
    {
        Player? player = await Db.Players.FirstOrDefaultAsync(player => player.Name == playerName);
        if (player == null)
        {
            player = new()
            {
                Name = playerName,
                GameCount = 1,
                AverageAttempts = attempts,
                AverageSecondsPerGame = time
            };
            Db.Players.Add(player);
        }
        else
        {
            player.GameCount += 1;
            player.AverageAttempts = ((player.AverageAttempts * (player.GameCount-1)) + attempts) / (player.GameCount);
            player.AverageSecondsPerGame = ((player.AverageSecondsPerGame * (player.GameCount - 1)) + time) / (player.GameCount);
        }
        if(Db.SaveChanges() > 0)
        {
            return true;
        } 
        else
        {
            return false;
        }
    }
}
