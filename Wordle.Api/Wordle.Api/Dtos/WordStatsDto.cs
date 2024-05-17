namespace Wordle.Api.Dtos;

public class WordStatsDto
{
	public DateOnly Date { get; set; }
	public int NumberOfPlays { get; set; }
	public double AverageScore { get; set; }
	public double AverageSeconds { get; set; }
}
