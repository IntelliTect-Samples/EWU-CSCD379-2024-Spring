using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Models;
using Wordle.Api.DTOS;

namespace Wordle.Api.Services;

public class PlayerService
{
    private readonly WordleDbContext _context;

    private static object updateLock = new();
	private static object addLock = new();
    
    public PlayerService(WordleDbContext context)
	{
		_context = context;
	}

    public async Task<Player?> GetPlayer(string playerName)
    {
        return await _context.Players.FirstOrDefaultAsync(p => p.Name == playerName);
    }

    public async Task AddPlayer(PlayerDTO playerDto)
    {
	    Player existingPlayer = _context.Players.FirstOrDefault(player => player.Name == playerDto.Name);

	    if (existingPlayer != null)
	    {
		    _context.Players.Entry(existingPlayer).CurrentValues.SetValues(playerDto);
	    }
	    else
	    {
		    Player player = new()
		    {
			    Name = playerDto.Name,
			    GameCount = playerDto.GameCount,
			    AverageAttempts = playerDto.AverageAttempts,
			    AverageSecondsPerGame = playerDto.AverageSecondsPerGame
		    };
		    await _context.Players.AddAsync(player);
	    }
	    
	    await _context.SaveChangesAsync();

    }
    
    public async Task<Player[]> GetTopPlayers(int numberOfPlayers)
    {
        return await _context.Players.OrderBy(p => p.AverageAttempts).Take(numberOfPlayers).ToArrayAsync();
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