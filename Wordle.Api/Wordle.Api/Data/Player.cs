namespace Wordle.Api.Data;

public class Player
{
    public int PlayerId { get; private set; }
    public string Name { get; private set; }
    public int GameCount { get; private set; }
    public double AverageAttempts { get; private set; }
}
