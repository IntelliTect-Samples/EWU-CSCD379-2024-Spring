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
    public async Task<bool> PostGame(WordOfTheDayGameDto gameDto)
    {
        var wordOfTheDay = Db.WordsOfTheDays
            .Where(word => word.Word == gameDto.WordOfTheDay)
            .OrderByDescending(word => word.Date)
            .FirstOrDefault();
        
        if(wordOfTheDay == null)
        {
            return false;
        }
        
        WordOfTheDayGame game = new()
        {
            Attempts = gameDto.Attempts,
            IsWin = gameDto.IsWin,
            WordOfTheDay = wordOfTheDay,
        };

        Db.WordOfTheDayGames.Add(game);
        await Db.SaveChangesAsync();
        return true;
    }
}