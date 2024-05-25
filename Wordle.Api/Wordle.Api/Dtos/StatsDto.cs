namespace Wordle.Api.Dtos;

public class StatsDto
{
    public DateTime DatePlayed { get; set; }
    public int NumberOfPlays { get; set; }
    public double AverageScore { get; set; }
    public double AverageAttempts { get; set; }
    public bool HasPlayedWordOfTheDay { get; set; }
    
}