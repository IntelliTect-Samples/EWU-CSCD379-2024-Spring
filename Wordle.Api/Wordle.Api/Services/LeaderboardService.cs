using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Models;

namespace Wordle.Api.Services;

public class LeaderboardService
{
	private readonly AppDbContext _context;
	private static object _changingPlayerLock = new();
	private static object _addingPlayerLock = new();
	public LeaderboardService(AppDbContext context)
	{
		_context = context;
	}
	public async Task<List<PlayerDto>> GetTopScoresAsync()
	{
		return await _context.Players.
			OrderBy(player => player.AverageAttempts).
			Take(10).
			Select(player => new PlayerDto
			{
				Name = player.Name,
				GameCount = player.GameCount,
				AverageAttempts = player.AverageAttempts
			}).ToListAsync();
	}

	public async Task<Player> PostScoreAsync(PlayerDto request)
	{
		Player? foundPlayer = await _context.Players.FirstOrDefaultAsync(player => player.Name.Equals(request.Name));
		if (foundPlayer is not null)
		{
			lock (_changingPlayerLock)
			{
				double attempts = foundPlayer.AverageAttempts * foundPlayer.GameCount + request.AverageAttempts;
				foundPlayer.GameCount += request.GameCount;
				foundPlayer.AverageAttempts = attempts / foundPlayer.GameCount;
				_context.SaveChanges();
				return foundPlayer;
			}
		}
		else
		{
			lock (_addingPlayerLock)
			{
				foundPlayer = _context.Players.FirstOrDefault(player => player.Name.Equals(request.Name));
				if (foundPlayer is not null)
				{
					double attempts = foundPlayer.AverageAttempts * foundPlayer.GameCount + request.AverageAttempts;
					foundPlayer.GameCount += request.GameCount;
					foundPlayer.AverageAttempts = attempts / foundPlayer.GameCount;
					_context.SaveChanges();
					return foundPlayer;
				}
				else
				{
					Player addedPlayer = new()
					{
						AverageAttempts = request.AverageAttempts,
						GameCount = request.GameCount,
						Name = request.Name,
					};
					_context.Players.Add(addedPlayer);
					_context.SaveChanges();
					return addedPlayer;

				}

			}
		}
	}


}
