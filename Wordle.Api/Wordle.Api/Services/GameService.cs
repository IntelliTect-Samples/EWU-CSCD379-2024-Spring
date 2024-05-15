using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Models;

namespace Wordle.Api.Services;

public class GameService
{
	public AppDbContext Db { get; set; }

	public GameService(AppDbContext db)
	{
		Db = db;
	}

	public async Task<bool> AddGame(GameDto gameDto)
	{
		// Get todays date
		var today = DateOnly.FromDateTime(DateTime.UtcNow);

		// Get all the words that match our game word and load their WOTDs
		var word = Db.Words
			.Include(word => word.WordsOfTheDays)
			.Where(word => word.Text == gameDto.Word)
			.First();

		// Create a new game object to save to the DB
		Game game = new()
		{
			Attempts = gameDto.Attempts,
			IsWin = gameDto.IsWin,
			// Attempt to find the WOTD that best matches todays date
			WordOfTheDay = word.WordsOfTheDays
				.OrderByDescending(wotd => wotd.Date)
				.FirstOrDefault(wotd => wotd.Date < today.AddDays(-1)),
			Word = word
		};

		Db.Games.Add(game);
		await Db.SaveChangesAsync();
		return true;
	}

	public async Task<List<WordGameStatisticDto>> GetDailyWordStatistics(string name)
	{
		var lastTenWords = await Db.WordsOfTheDays.OrderBy(word => word.Date).Take(10).ToListAsync();
		List<WordGameStatisticDto> dailyWordStatistics = new();
		foreach(var word in lastTenWords)
		{
			int plays = 0;
			WordGameStatisticDto statistic = new()
			{
				// put stuff in
			};
		}
	}
}
