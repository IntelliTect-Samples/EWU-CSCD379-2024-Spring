using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Dtos;
using Wordle.Api.Services;
using Wordle.Api.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Wordle.Api.Controllers
{
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
        public async Task<IActionResult> AddWord(WordDto word)
        {
            try
            {
                await _wordEditorService.AddWord(word);
                return CreatedAtAction(nameof(GetWordOfDay), new { word.Word }, word);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = Authorize.WordMaster)]
        public async Task<IActionResult> DeleteWord(int id)
        {
            var wordToDelete = await _wordEditorService.DeleteWordById(id);
            if (wordToDelete == null)
            {
                return NotFound("Word not found.");
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Policy = Authorize.WordMaster)]
        public async Task<IActionResult> UpdateWord(int id, WordDto wordDto)
        {
            if (id != wordDto.Id)
            {
                return BadRequest("Word ID mismatch.");
            }

            var wordToUpdate = await _wordEditorService.UpdateWord(id, wordDto);
            if (wordToUpdate == null)
            {
                return NotFound("Word not found.");
            }

            return NoContent();
        }

        [HttpGet("SearchWords")]
        public async Task<ActionResult<NewWordDto>> SearchWords(string query = "", int page = 1, int pageSize = 10)
        {
            var words = await _wordOfTheDayService.SearchWords(query, page, pageSize);
            return Ok(words);
        }
    }
}
