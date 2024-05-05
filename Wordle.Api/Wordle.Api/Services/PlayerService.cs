using Microsoft.EntityFrameworkCore;
using Wordle.Api.Models;

namespace Wordle.Api.Services;

public class PlayerService
{
    public WordleDbContext Db { get; set; }
    
    public PlayerService(WordleDbContext db)
    {
        Db = db;
    }
    
    public async Task<Player[]> GetTopPlayers(int numberOfPlayers)
    {
        return await Db.Players.OrderByDescending(p => p.AverageAttempts).Take(numberOfPlayers).ToArrayAsync();
    }
    
    public async Task AddPlayer(Player player)
    {
        if (!Db.Players.Contains(player))
        {
            await Db.Players.AddAsync(player);
            await Db.SaveChangesAsync();
        }
        
    }
}