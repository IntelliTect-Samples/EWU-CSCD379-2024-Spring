using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Models;
public class Game
{
    public int GameId { get; set; }

    public int Attempts { get; set; }
    public int Seconds {  get; set; }

    public bool IsWin {  get; set; }

    public string Name { get; set; } = null!;

    public DateTime DateAttempted { get; set; } = DateTime.UtcNow;

    public int? WordOfTheDayId { get; set; }
    public WordOfTheDay? WordOfTheDay { get; set; }

    [Required]
    public int WordId { get; set; }
    public Word? Word { get; set; }
}
