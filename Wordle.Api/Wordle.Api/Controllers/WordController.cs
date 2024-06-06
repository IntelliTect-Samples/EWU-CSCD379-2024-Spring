using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Dtos;
using Wordle.Api.Identity;
using Wordle.Api.Services;
using Wordle.Api.Models;

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

    [Authorize(Roles = Roles.Admin)]
    [HttpGet("WordOfTheDayHint")]
    public async Task<string> GetWordOfDayHint(double offsetInHours = -7.0)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.UtcNow.AddHours(offsetInHours));
        var wordOfTheDay = await wordOfTheDayService.GetWordOfTheDay(today);

        return wordOfTheDay.Substring(0, 1) + "___" + wordOfTheDay.Substring(4, 1);
    }

    [HttpGet("SecuredRandomWord")]
    [Authorize(Policy = Policies.RandomAdmin)]
    public async Task<string> GetSecuredRandomWord()
    {
        var randomWord = await wordOfTheDayService.GetRandomWord("sec");
        return randomWord.Text;
    }


    [HttpGet("WordByDate/{month}/{day}/{year}")]
    public async Task<string?> GetWordByDate(int month, int day, int year)
    {
        DateOnly date = new DateOnly(year, month, day);
        return await wordOfTheDayService.GetWordOfTheDay(date);
    }

    [HttpPost("DeleteWord")]
    [Authorize(Policy = Policies.OlderThanTwentyOne)]
    [Authorize(Policy = Policies.MasterOfTheUniverse)]
    public async Task<bool> DeleteWord(string word)
    {
		bool isDeleted = await wordOfTheDayService.DeleteWord(word.Trim().ToLower());
        return isDeleted;
	}

	[HttpPost("AddWord")]
    [Authorize(Policy = Policies.OlderThanTwentyOne)]
	[Authorize(Policy = Policies.MasterOfTheUniverse)]
	public async Task<bool> AddWord(string word)
	{
		bool isAdded = await wordOfTheDayService.AddWord(word.Trim().ToLower());
        return isAdded;
	}

    [HttpPost("ChangeCommonWordFlag")]
    [Authorize]
    public async Task<bool> ChangeCommonWordFlag(WordDto dto)
    {
        bool isChanged = await wordOfTheDayService.ChangeCommonWordFlag(dto.Word.Trim().ToLower(), dto.IsCommonWord);
        return isChanged;
    }

    [HttpGet("GetAllWords")]
    public async Task<List<WordDto>> GetAllWords()
    {
        return await wordOfTheDayService.GetAllWords();
    }
    [HttpGet("GetMoreWords")]
    public async Task<MoreWordsDto> GetMoreWords(int wordCount = 1, string word = "", int pages = 10)
    {
        return await wordOfTheDayService.GetMoreWords(wordCount, word, pages);
    }
}