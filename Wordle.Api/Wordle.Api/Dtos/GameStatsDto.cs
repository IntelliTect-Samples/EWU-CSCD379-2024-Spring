namespace Wordle.Api.Dtos;

public class GameStatsDto
{
    public required string Word { get; set; }
    public double AverageGuesses { get; set; }
    public int TotalTimesPlayed { get; set; }
    public int TotalWins { get; set; }
    public int TotalLosses => TotalTimesPlayed - TotalWins;
}