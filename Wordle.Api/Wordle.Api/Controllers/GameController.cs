using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Dtos;
using Wordle.Api.Models;

namespace Wordle.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    public WordleDbContext Db { get; set; }

    public GameController(WordleDbContext db)
    {
        Db = db;
    }

    [HttpPost("Game")]
    public async Task<bool> PostGame(GameDto gameDto)
    {
        var wordOfTheDay = Db.WordsOfTheDays
            .Where(word => word.WordId == gameDto.WordOfTheDayId)
            .OrderByDescending(word => word.Date)
            .FirstOrDefault();

        if (wordOfTheDay == null)
        {
            // TODO: We need better error messages here
            // our users are upset
            return false;
        }

        Game game = new()
        {
            Attempts = gameDto.Attempts,
            IsWin = gameDto.IsWin,
            WordOfTheDay = wordOfTheDay,
        };

        Db.Games.Add(game);
        await Db.SaveChangesAsync();
        return true;
    }
}
