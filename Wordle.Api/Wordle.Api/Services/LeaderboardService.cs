using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Requests;

namespace Wordle.Api.Services;

public class LeaderboardService
{
	private readonly AppDbContext _context;
	public LeaderboardService(AppDbContext context)
	{
		_context = context;
	}
	public List<PlayerDto> GetTopScores()
	{
		List<Player> players = _context.Players.
			OrderBy(player => player.AverageAttempts).ToList();
		return players.Select(player =>
		{
			return new PlayerDto
			{
				Name = player.Name,
				GameCount = player.GameCount,
				AverageAttempts = player.AverageAttempts
			};
		}).ToList();
	}

	public async Task<Player> PostScore(PlayerRequest request)
	{
		Player? foundPlayer = _context.Players.FirstOrDefault(p => request.Name.Equals(p.Name));
		if (foundPlayer is not null)
		{
			double attempts = foundPlayer.AverageAttempts * foundPlayer.GameCount + request.Attempts;
			foundPlayer.GameCount = request.GameCount;
			foundPlayer.AverageAttempts = attempts / foundPlayer.GameCount;
			await _context.SaveChangesAsync();
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
			await _context.Players.AddAsync(addedPlayer);
			await _context.SaveChangesAsync();
			return addedPlayer;
		}
	}
}
