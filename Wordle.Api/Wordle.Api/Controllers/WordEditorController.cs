using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordEditorController(WordEditorService wordEditorService) : ControllerBase
    {
        [HttpPost("DeleteWord")]
        public async Task<IActionResult> DeleteWord(string word)
        {
            var result = await wordEditorService.DeleteWordAsync(word);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
