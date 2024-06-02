using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Dtos;
using Wordle.Api.Models;
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

            return result ? Ok() : BadRequest();
        }
        
        [HttpPost("AddWord")]
        public async Task<IActionResult> AddWord(string word)
        {
            var result = await wordEditorService.AddWordAsync(word);
            
            return result ? Ok() : BadRequest();
        }
        
        [HttpGet("GetWords")]
        public async Task<IActionResult> GetWords(string search = "", int page = 1, int itemsPerPage = 10, bool isCommonFilter = false)
        {
            var result = await wordEditorService.GetWordsAsync(search, page, itemsPerPage, isCommonFilter);
            return Ok(new
            {
                words = result.Item1,
                totalCount = result.Item2
            });
        }
        
        [HttpPost("SetIsCommon")]
        public async Task<IActionResult> SetIsCommon(string word, bool isCommon)
        {
            var result = await wordEditorService.SetIsCommonAsync(word, isCommon);
            
            return result ? Ok() : BadRequest();
        }
    }
}
