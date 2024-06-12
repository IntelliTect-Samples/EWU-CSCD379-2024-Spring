using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Models;
public class Game
{
    public int GameId { get; set; }
    public int Attempts { get; set; }
    public bool IsWin { get; set; }
    public DateTime DateAttempted { get; set; }
    public int WordId { get; set; }
    public int? WordOfTheDayId { get; set; }

    public Word Word { get; set; } = null!;
    public WordOfTheDay? WordOfTheDay { get; set; }
}