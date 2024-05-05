using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordController(WordOfTheDayService wordOfTheDayService) : ControllerBase
    {
        [HttpGet("RandomWord")]
        public string GetRandomWord()
        {
            return wordOfTheDayService.GetRandomWord();
        }

        [HttpGet("WordOfTheDay")]
        public async Task<string> GetWordOfDay(double offsetInHours = -7.0)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.UtcNow.AddHours(offsetInHours));
            return await wordOfTheDayService.GetWordOfTheDay(today);
        }
    }
}
