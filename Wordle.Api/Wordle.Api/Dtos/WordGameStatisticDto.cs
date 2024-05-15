namespace Wordle.Api.Dtos;

public class WordGameStatisticDto
{
    public int Plays { get; set; }
    public double AverageScore { get; set; }
    public double AverageTime { get; set; }
    public bool HasPlayed { get; set; }
    public DateOnly Date { get; set; }
}
