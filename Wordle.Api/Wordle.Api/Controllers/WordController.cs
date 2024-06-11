using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Dtos;
using Wordle.Api.Services;
using Wordle.Api.Identity;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WordController : ControllerBase
{
    private readonly WordOfTheDayService _wordOfTheDayService;
    private readonly WordEditorService _wordEditorService;

    public WordController(WordOfTheDayService wordOfTheDayService, WordEditorService wordEditorService)
    {
        _wordOfTheDayService = wordOfTheDayService;
        _wordEditorService = wordEditorService;
    }

    [HttpGet("RandomWord")]
    public async Task<string> GetRandomWord()
    {
        var randomWord = await _wordOfTheDayService.GetRandomWord();
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
        return await _wordOfTheDayService.GetWordOfTheDay(today);
    }

    [HttpGet("WordOfTheDay/{date}")]
    public async Task<IActionResult> GetWordOfDay(string date)
    {
        if (!DateOnly.TryParse(date, out var parsedDate))
        {
            return BadRequest("Invalid date format.");
        }

        var word = await _wordOfTheDayService.GetWordOfTheDay(parsedDate);
        return Ok(word);
    }

    [HttpGet("WordsList")]
    public async Task<NewWordDto> GetWordsList(string query = "", int page = 1, int pageSize = 10)
    {
        return await _wordOfTheDayService.GetWordsList(query, page, pageSize);
    }

    [HttpPost("AddWord")]
    [Authorize(Policy = Authorize.WordMaster)]
    public async Task AddWord(WordDto word)
    {
        await _wordEditorService.AddWord(word);
    }

    [HttpDelete("DeleteWord")]
    [Authorize(Policy = Authorize.WordMaster)]
    public async Task DeleteWord(string word)
    {
        await _wordEditorService.DeleteWord(word);
    }

    [HttpPost("EditWord")]
    [Authorize]
    public async Task EditWord(WordDto word)
    {
        await _wordEditorService.UpdateWord(word);
    }
}