using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Wordle.Api.Models;
using Wordle.Api.Dtos;

namespace Wordle.Api.Services
{
  public class WordleService 
  {
    private readonly WordleDbContext _context;

    public WordleService(WordleDbContext context)
    {
      _context = context;
    }

    public async Task<Player[]> GetTop10Scores()
    {
      return await _context.Players.OrderByDescending(p => p.AverageAttempts).ThenBy(p => p.GameCount).Take(10).ToArrayAsync();
    }

    public async Task<Player> AddOrUpdatePlayer(PlayerDTO player)
    {
      Player? existingPlayer = await _context.Players.FirstOrDefaultAsync(player => player.Name == player.Name);
      if(existingPlayer != null)
      {
        existingPlayer.GameCount++;
        existingPlayer.AverageAttempts = (existingPlayer.AverageAttempts * (existingPlayer.GameCount - 1) + player.AverageAttempts) / existingPlayer.GameCount;
        existingPlayer.AverageSecondsPerGame = (existingPlayer.AverageSecondsPerGame * (existingPlayer.GameCount - 1) + player.AverageSecondsPerGame) / existingPlayer.GameCount;
        _context.SaveChanges();
        return existingPlayer;
      }
      else 
      {
        Player newPlayer = new(){
          AverageAttempts = player.AverageAttempts,
          GameCount = player.GameCount,
          Name = player.Name,
          AverageSecondsPerGame = player.AverageSecondsPerGame
        };
        _context.Players.Add(newPlayer);
        _context.SaveChanges();
        return newPlayer;
      }
    }
  }
}
