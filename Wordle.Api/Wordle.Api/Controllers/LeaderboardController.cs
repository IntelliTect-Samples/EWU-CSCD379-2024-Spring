using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Models;
using Wordle.Api.Service;

namespace Wordle.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LeaderboardController : ControllerBase 
  {
    private readonly WordleService _wordleService;

    public LeaderboardController(WordleService wordleService)
    {
      _wordleService = wordleService;
    }

    [HttpGet("top10")]
    public IActionResult GetTop10Scores()
    {
      var top10Scores = _wordleService.GetTop10Scores();
      return Ok(top10Scores);
    }

    [HttpPost]
    public IActionResult PostScore(Player player)
    {
      _wordleService.AddOrUpdatePlayer(player);
      return Ok();
    }
  }
}
