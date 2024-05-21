using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Wordle.Api.Dtos;
using Wordle.Api.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Wordle.Api.Services;

public class PlayerService
{
    private static object _lock = new();

    public WordleDbContext Db { get; set; }

    public PlayerService(WordleDbContext db)
    {
        Db = db;
    }

    /*public async Task<Player> GetPlayer(string name)
    {
    }*/

    public async Task<List<PlayerDto>> GetTopScores(int num)
    {
        return await Db.Players.
            OrderBy(player => player.AverageAttempts).
            Take(num).
            Select(player => new PlayerDto
            {
                //player name cannot be null
                Name = player.Name!,
                AverageAttempts = player.AverageAttempts,
                GameCount = player.GameCount
            }).ToListAsync();
    }

    public async Task<bool> UpdateScore(ScoreDto score)
    {
        Player? player = await Db.Players.FirstOrDefaultAsync(player => player.Name == score.PlayerName);
        lock (_lock)
        {
            if (player == null)
            {
                player = new()
                {
                    Name = score.PlayerName,
                    GameCount = 1,
                    AverageAttempts = score.Attempts,
                    AverageSecondsPerGame = score.Time
                };
                Db.Players.Add(player);
            }
            else
            {
                player.GameCount += 1;
                player.AverageAttempts = ((player.AverageAttempts * (player.GameCount - 1)) + score.Attempts) / (player.GameCount);
                player.AverageSecondsPerGame = ((player.AverageSecondsPerGame * (player.GameCount - 1)) + score.Time) / (player.GameCount);
            }
            if (Db.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
