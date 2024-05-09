using Microsoft.EntityFrameworkCore;
using Wordle.Api.Models;

namespace Wordle.Api.Services;

public class PlayerService
{
    public WordleDbContext Db { get; set; } = Db;

    private static object updateLock = new();
	private static object addLock = new();
    

    public async Task<Player?> GetPlayer(string playerName)
    {
        return await Db.Players.FirstOrDefaultAsync(p => p.name == playerName);
    }
    
    public async Task<Player[]> GetTopPlayers(int numberOfPlayers)
    {
        return await Db.Players.OrderBy(p => p.averageAttempts).Take(numberOfPlayers).ToArrayAsync();
    }
    
    public async Task AddPlayer(Player request)
    {
        Player? curPlayer = await Db.Players.FirstOrDefaultAsync(request => request.name.Equals(request.name));
		if (curPlayer != null)
		{
			lock (updateLock)
			{
				double attempts = curPlayer.averageAttempts * curPlayer.gameCount + request.averageAttempts;
				curPlayer.averageAttempts = attempts / (curPlayer.gameCount + 1);
                //int seconds = curPlayer.averageSecondsPerGame * curPlayer.gameCount + request.averageSecondsPerGame;
                //curPlayer.averageSecondsPerGame = seconds/ (curPlayer.gameCount + 1);
                curPlayer.gameCount = curPlayer.gameCount + 1;
			}
		}
		else
		{
			lock (addLock)
			{
                Player newPlayer = new()
                {
                    averageAttempts = request.averageAttempts,
                    gameCount = request.gameCount,
                    name = request.name,
                    //AverageSecondsPerGame = request.averageSecondsPerGame
                };
                Db.Players.Add(newPlayer);
			}
		}
        Db.SaveChanges();
    }
}