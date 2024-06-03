using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Dtos;
using Wordle.Api.Identity;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class WordController(WordOfTheDayService wordOfTheDayService, WordEditService wordEditService) : ControllerBase
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

    [HttpGet("WordsList/")]
    public async Task<WordListDto> GetWordList(string query = "", int page = 1, int pageSize = 10)
    {
        return await wordOfTheDayService.GetWordList(query, page, pageSize);
    }

    [HttpPost("AddWord")]
    [Authorize(Policy = Policies.AddOrRemoveWords)]
    public async Task AddWord(WordDto word)
    {
        await wordEditService.AddWord(word);
    }

    [HttpDelete("RemoveWord")]
    [Authorize(Policy = Policies.AddOrRemoveWords)]
    public async Task RemoveWord(string word)
    {
        await wordEditService.RemoveWord(word);
    }

    [HttpPost("UpdateWord")]
    [Authorize]
    public async Task UpdateWord(WordDto word)
    {
        await wordEditService.UpdateWord(word);
    }
}
