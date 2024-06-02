using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Dtos;
using Wordle.Api.Identity;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class WordController(WordOfTheDayService wordOfTheDayService, WordEditorService wordEditorService) : ControllerBase
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

    [HttpGet("WordOfTheDay/{date}")]
    public async Task<string> GetWordOfDay(DateTime date)
    {
        DateOnly dateOnly = DateOnly.FromDateTime(date);
        return await wordOfTheDayService.GetWordOfTheDay(dateOnly);
    }

    [HttpGet("WordsList/")]
    public async Task<List<WordDto>> GetWordsList(string query = "", int page = 1, int pageSize = 10)
    {
        return await wordOfTheDayService.GetWordsList(query, page, pageSize);
    }

    [HttpPost("AddWord")]
    [Authorize(Policy = Policies.EditWord)]
    public async Task AddWord(WordDto word)
    {
        await wordEditorService.AddWord(word);
    }

    [HttpDelete("DeleteWord")]
    [Authorize(Policy = Policies.EditWord)]
    public async Task DeleteWord(string word)
    {
        await wordEditorService.DeleteWord(word);
    }

    [HttpPost("EditWord")]
    [Authorize]
    public async Task EditWord(WordDto word)
    {
        await wordEditorService.UpdateWord(word);
    }
}
