namespace Wordle.Api.Models;

public class Player
{
    public int PlayerId { get; set; }
    public string Name { get; set; } = null!;
    public int GameCount { get; set; }
    public double AverageAttempts { get; set; }
}
