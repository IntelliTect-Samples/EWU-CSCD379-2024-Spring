using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Models;
using Wordle.Api.Requests;

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
	public async Task<List<PlayerDto>> GetTopScores()
	{
		return await _context.Players.
			OrderBy(player => player.AverageAttempts).
			Select(player => new PlayerDto
			{
				Name = player.Name,
				GameCount = player.GameCount,
				AverageAttempts = player.AverageAttempts
			}).ToListAsync();
	}

	public async Task<Player> PostScore(PlayerRequest request)
	{
		Player? foundPlayer = await _context.Players.FirstOrDefaultAsync(player => request.Name.Equals(player.Name));
		if (foundPlayer is not null)
		{
			lock (_changingPlayerLock)
			{
				double attempts = foundPlayer.AverageAttempts * foundPlayer.GameCount + request.Attempts;
				foundPlayer.GameCount = request.GameCount;
				foundPlayer.AverageAttempts = attempts / foundPlayer.GameCount;
				_context.SaveChanges();
				return foundPlayer;
			}
		}
		else
		{
			lock (_addingPlayerLock)
			{
				foundPlayer = _context.Players.FirstOrDefault(player => request.Name.Equals(player.Name));
				if (foundPlayer is not null)
				{
					double attempts = foundPlayer.AverageAttempts * foundPlayer.GameCount + request.Attempts;
					foundPlayer.GameCount = request.GameCount;
					foundPlayer.AverageAttempts = attempts / foundPlayer.GameCount;
					_context.SaveChanges();
					return foundPlayer;
				}
				else
				{
					Player addedPlayer = new()
					{
						AverageAttempts = request.Attempts,
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
