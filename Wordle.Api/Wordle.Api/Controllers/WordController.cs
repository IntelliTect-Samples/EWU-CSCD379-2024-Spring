using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Services;

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

    [Authorize]
    [HttpGet("WordOfTheDayHint")]
    public async Task<string> GetWordOfDayHint(double offsetInHours = -7.0)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.UtcNow.AddHours(offsetInHours));
        var wordOfTheDay = await wordOfTheDayService.GetWordOfTheDay(today);

        return wordOfTheDay.Substring(0, 1) + "___" + wordOfTheDay.Substring(4,1);
    }
}
