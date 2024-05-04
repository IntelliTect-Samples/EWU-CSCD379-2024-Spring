using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordController(WordOfTheDayService wordOfTheDayService) : ControllerBase
    {
        [HttpGet(Name = "GetWord")]
        public string Get()
        {
            return wordOfTheDayService.GetRandomWord();
        }
    }
}
