using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Identity;
using Wordle.Api.Services;
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


    [HttpGet("GetWordList")]
    public async Task<WordList> GetWordList(string search="", int pageNum = 1, int pageSize = 10){
      return await wordOfTheDayService.GetWordList(search, pageNum, pageSize);
    }

    [HttpDelete("DeleteWord")]
    [Authorize(Policy = Policies.MasterOfTheUniverse)]
    [Authorize(Policy = Policies.IsTwentyOne)]
    public async Task DeleteWord(string word){
      await wordOfTheDayService.DeleteWord(word);
    }

    [HttpPost("AddWord")]
    [Authorize(Policy = Policies.MasterOfTheUniverse)]
    [Authorize(Policy = Policies.IsTwentyOne)]
    public async Task AddWord(WordsDto word){
      await wordOfTheDayService.AddWord(word);
    }
}
