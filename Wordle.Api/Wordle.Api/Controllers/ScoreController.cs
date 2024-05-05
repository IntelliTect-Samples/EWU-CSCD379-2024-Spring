using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Models;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ScoreController(ScoreService scoreService) : ControllerBase
{
    [HttpGet("TopScores")]
    public async Task<Score[]> GetTopScores()
    {
        return await scoreService.GetTopScores();
    }
    
    [HttpPost("AddScore")]
    public async Task<Player> AddScore(Player player)
    {
        await scoreService.AddScore(player);
        return player;
    }
    
}