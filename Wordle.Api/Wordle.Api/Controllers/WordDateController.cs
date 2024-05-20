using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Models;
using Wordle.Api.Services;
using Wordle.Api.Dtos;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WordDateController(WordDateService wordDateService) : ControllerBase
{

    [HttpGet("WordDate")]
    public async Task<WordDate?> GetWordDate(string date)
    {
        return await wordDateService.GetWordDate(date) ?? null;
    }
    
    [HttpGet("RecentWordDates")]
    public async Task<WordDate[]> GetRecentWordDates(int numberOfWordDates = 10)
    {
        return await wordDateService.GetRecentWordDates(numberOfWordDates);
    }
    
    [HttpPost("AddWordDate")]
	public async Task<WordDateDTO?> Post(WordDateDTO wordDateDTO)
	{
		await wordDateService.AddWordDate(wordDateDTO);
        return wordDateDTO;
	}
}