using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Models;
public class Game
{
    public int GameId { get; set; }

    public int Attempts { get; set; }

    public double Time {  get; set; }

    public bool IsWin {  get; set; }

    public DateTime DateAttempted { get; set; } = DateTime.UtcNow.AddHours(-7);

    public int? WordOfTheDayId { get; set; }
    public WordOfTheDay? WordOfTheDay { get; set; }

    public string? PlayerName { get; set; }

    [Required]
    public int WordId { get; set; }
    public Word? Word { get; set; }
}
