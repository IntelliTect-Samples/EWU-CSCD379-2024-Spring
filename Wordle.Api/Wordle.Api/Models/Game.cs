using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Models;
public class Game
{
    public int GameId { get; set; }

    public int Attempts { get; set; }

    public bool IsWin {  get; set; }

    public DateTime DateAttempted { get; set; } = DateTime.UtcNow;

    [Required]
    public int WordOfTheDayId { get; set; }
    public WordOfTheDay? WordOfTheDay { get; set; }
}
