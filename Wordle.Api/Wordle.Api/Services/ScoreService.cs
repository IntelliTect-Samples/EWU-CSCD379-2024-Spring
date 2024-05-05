using Microsoft.EntityFrameworkCore;
using Wordle.Api.Models;

namespace Wordle.Api.Services;

public class ScoreService
{
    public WordleDbContext Db { get; set; }
    
    public ScoreService(WordleDbContext db)
    {
        Db = db;
    }

    public async Task<Score[]> GetTopScores(Player player)
    {
        return await Db.Scores
            .Where(s => s.PlayerId == player.PlayerId)
            .OrderByDescending(s => s.AverageGuesses)
            .Take(10)
            .ToArrayAsync();
    }
    
    public async Task AddScore(Player player)
    {
        var score = new Score
        {
            PlayerId = player.PlayerId,
            AverageGuesses = player.AverageAttempts,
            GamesPlayed = player.GameCount
        };
        
        if(Db.Scores.Any(s => s.PlayerId == player.PlayerId))
        {
            Db.Scores.Update(score);
        }
        else
        {
            Db.Scores.Add(score);
        }
        
        
        await Db.SaveChangesAsync();
    }
}