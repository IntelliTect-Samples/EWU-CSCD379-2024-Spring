using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Services;
using System;
using Wordle.Api.Dtos;

namespace Wordle.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class WordController(WordOfTheDayService wordOfTheDayService) : ControllerBase
{
    [HttpGet("RandomWord")]
    public async Task<string> GetRandomWord()
    {
        var randomWord = await wordOfTheDayService.GetRandomWord();
        return randomWord.Text;
    }

    /// <summary>
    /// Get the word of the day.
    /// </summary>
    /// <param name="offsetInHours">Timezone offset in hours. Default to PST</param>
    /// <returns></returns>
    [HttpGet("WordOfTheDay")]
    public async Task<string> GetWordOfDay(double offsetInHours = -7.0)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.UtcNow.AddHours(offsetInHours));
        return await wordOfTheDayService.GetWordOfTheDay(today);
    }

    //Attempted Controller for getting stats 
    /*
    [HttpGet("WordStats")]
    public async Task<ActionResult<GameStatsDto>> GetWordStats(string word)
    {
      var wordStats = await wordOfTheDayService.GetWordStats(word);

      if(string.IsNullOrEmpty(wordStats.Word))
        return NotFound();

      return Ok(wordStats);
    }
    */

}
