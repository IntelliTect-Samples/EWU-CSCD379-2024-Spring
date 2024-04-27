using Wordle.Api.Data;
using Wordle.Api.Requests;

namespace Wordle.Api.Services;

public class LeaderboardService
{
	private readonly AppDbContext _context;
	public LeaderboardService(AppDbContext context)
	{
		_context = context;
	}
	public List<Player> GetTopScores()
	{
		return _context.Players.
			OrderBy(player => player.AverageAttempts).ToList();
	}

	public async Task<Player> PostScore(PlayerRequest request)
	{
		if (request.PlayerId is not null)
		{
			Player foundPlayer = _context.Players.First(p => request.PlayerId == p.PlayerId); // Using .First because I am assuming front end will not give bad player id
			foundPlayer.AverageAttempts = request.AverageAttempts;
			foundPlayer.GameCount = request.GameCount;
			foundPlayer.Name = request.Name;
			await _context.SaveChangesAsync();
			return foundPlayer;
		}
		else
		{
			Player addedPlayer = new Player()
			{
				AverageAttempts = request.AverageAttempts,
				GameCount = request.GameCount,
				Name = request.Name,
			};
			await _context.Players.AddAsync(addedPlayer);
			await _context.SaveChangesAsync();
			return addedPlayer;
		}
	}
}
