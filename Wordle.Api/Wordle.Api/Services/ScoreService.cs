using Microsoft.EntityFrameworkCore;
using Wordle.Api.Models;

namespace Wordle.Api.Services;

public class ScoreService
{
    private readonly AppDbContext _context;
    private static object updateLock = new();
	private static object addLock = new();
    
    public ScoreService(AppDbContext context)
	{
		_context = context;
	}
    

    public async Task<List<PlayerDTO>> GetTopScores()
    {
        return await _context.Players.
			OrderBy(player => player.AverageAttempts).
            .ThenBy(player => player.GamesPlayed)
			Take(10).
			Select(player => new PlayerDTO
			{
				Name = player.Name,
				GameCount = player.GameCount,
				AverageAttempts = player.AverageAttempts
                AverageSecondsPerGame = player.AverageSecondsPerGame;
			}).ToListAsync();

    }
    
    public async Task<Player> AddScore(PlayerDTO player)
    {
        Player? curPlayer = await _context.Players.FirstOrDefaultAsync(player => player.Name.Equals(request.Name));
		if (curPlayer != null)
		{
			lock (updateLock)
			{
				double attempts = curPlayer.AverageAttempts * curPlayer.GameCount + request.AverageAttempts;
				curPlayer.AverageAttempts = attempts / (curPlayer.GameCount + 1);
                int seconds = curPlayer.AverageSecondsPerGame * curPlayer.GameCount + request.AverageSecondsPerGame;
                curPlayer.AverageSecondsPerGame = seconds/ (curPlayer.GameCount + 1);
                curPlayer.GameCount = curPlayer.GameCount + 1;
				_context.SaveChanges();
				return curPlayer;
			}
		}
		else
		{
			lock (addLock)
			{
				curPlayer = _context.Players.FirstOrDefault(player => player.Name.Equals(request.Name));
				if (curPlayer != null)
				{
					double attempts = curPlayer.AverageAttempts * curPlayer.GameCount + request.AverageAttempts;
                    curPlayer.AverageAttempts = attempts / (curPlayer.GameCount + 1);
                    int seconds = curPlayer.AverageSecondsPerGame * curPlayer.GameCount + request.AverageSecondsPerGame;
                    curPlayer.AverageSecondsPerGame = seconds/ (curPlayer.GameCount + 1);
                    curPlayer.GameCount = curPlayer.GameCount + 1;
                    _context.SaveChanges();
                    return curPlayer;
				}
				else
				{
					Player newPlayer = new()
					{
						AverageAttempts = request.AverageAttempts,
						GameCount = request.GameCount,
						Name = request.Name,
                        AverageSecondsPerGame = request.AverageSecondsPerGame
					};
					_context.Players.Add(newPlayer);
					_context.SaveChanges();
					return newPlayer;
				}

			}
		}
    }
}