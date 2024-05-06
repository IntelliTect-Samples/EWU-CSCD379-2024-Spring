using System.Collections.Generic;
using System.Linq;
using Wordle.Api.Models;

namespace Wordle.Api.Services
{
  public class WordleService 
  {
    private readonly ApplicationDbContext _context;

    public WordleService(ApplicationDbContext context)
    {
      _context = context;
    }

    public List<Player> GetTop10Scores()
    {
      return _context.Players.OrderByDescending(p => p.AverageAttempts).ThenBy(p => p.GameCount).Take(10).ToList();
    }

    public void AddOrUpdatePlayer(Player player)
    {
      var existingPlayer = _context.Players.FirstOrDefault(p => p.Name == player.Name);
      if(existingPlayer != null)
      {
        existingPlayer.GameCount++;
        existingPlayer.AverageAttempts = (existingPlayer.AverageAttempts * (existingPlayer.GameCount - 1) + player.AverageAttempts) / existingPlayer.GameCount;
        existingPlayer.AverageSecondsPerGame = (existingPlayer.AverageSecondsPerGame * (existingPlayer.GameCount - 1) + player.AverageSecondsPerGame) / existingPlayer.GameCount;
      }
      else 
      {
        _context.Players.Add(player);
      }
      _context.SaveChanges();
    }
  }
}
