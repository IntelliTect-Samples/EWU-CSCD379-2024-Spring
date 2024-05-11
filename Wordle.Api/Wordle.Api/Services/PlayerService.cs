using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Models;

namespace Wordle.Api.Services;

public class PlayerService
{
    public WordleDbContext Db { get; set; }

    private static object updateLock = new();
	private static object addLock = new();
    

    public async Task<Player?> GetPlayer(string playerName)
    {
        return await Db.Players.FirstOrDefaultAsync(p => p.name == playerName);
    }

    public async Task AddPlayer(Player playerDto)
    {
	    Player existingPlayer = _context.Players.FirstOrDefault(player => player.name == playerDto.name);

	    if (existingPlayer != null)
	    {
		    Db.Players.Entry(existingPlayer).CurrentValues.SetValues(playerDto);
	    }
	    else
	    {
		    Player player = new()
		    {
			    name = playerDto.name,
			    gameCount = playerDto.gameCount,
			    averageAttempts = playerDto.averageAttempts,
			    averageSecondsPerGame = playerDto.averageSecondsPerGame
		    };
		    await Db.Players.AddAsync(player);
	    }
	    
	    return await Db.SaveChangesAsync();

    }
    
    public async Task<Player[]> GetTopPlayers(int numberOfPlayers)
    {
        return await Db.Players.OrderBy(p => p.averageAttempts).Take(numberOfPlayers).ToArrayAsync();
    }
    
    // Tim's AddPlayer method
    
  //   public async Task<Player> AddPlayer(PlayerDTO request)
  //   {
  //       Player? curPlayer = await _context.Players.FirstOrDefaultAsync(request => request.Name.Equals(request.Name));
		// if (curPlayer != null)
		// {
		// 	lock (updateLock)
		// 	{
		// 		double attempts = curPlayer.AverageAttempts * curPlayer.GameCount + request.AverageAttempts;
		// 		curPlayer.AverageAttempts = attempts / (curPlayer.GameCount + 1);
  //               int seconds = curPlayer.AverageSecondsPerGame * curPlayer.GameCount + request.AverageSecondsPerGame;
  //               curPlayer.AverageSecondsPerGame = seconds/ (curPlayer.GameCount + 1);
  //               curPlayer.GameCount = curPlayer.GameCount + 1;
		// 		_context.SaveChanges();
		// 		return curPlayer;
		// 	}
		// }
		// else
		// {
		// 	lock (addLock)
		// 	{
  //               Player newPlayer = new()
  //               {
  //                   AverageAttempts = request.AverageAttempts,
  //                   GameCount = request.GameCount,
  //                   Name = request.Name,
  //                   AverageSecondsPerGame = request.AverageSecondsPerGame
  //               };
  //               _context.Players.Add(newPlayer);
  //               _context.SaveChanges();
  //               return newPlayer;
		// 	}
		// }
  //   }
}