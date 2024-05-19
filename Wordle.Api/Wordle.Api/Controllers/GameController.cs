using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Dtos;
using Wordle.Api.Models;

namespace Wordle.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class GameController(WordleDbContext Db) : ControllerBase
{
    [HttpPost("Game")]
    public async Task<bool> PostGame(GameDto gameDto)
    {
        var wordOfTheDay = Db.WordsOfTheDays
            .Where(word => word.WordId == gameDto.WordOfTheDayId)
            .OrderByDescending(word => word.Date)
            .FirstOrDefault();
        
        if(wordOfTheDay == null)
        {
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