using System.ComponentModel.DataAnnotations.Schema;

namespace Wordle.Api.Models;

[Table("Players")]
public class Player
{
    public int playerId { get; set; }
    public string name { get; set; } = null!;
    public int gameCount { get; set; }
    public double averageAttempts { get; set; }
    public int averageSecondsPerGame { get; set; }
}