namespace Wordle.Api.Dtos;

public record PlayerDto
{
	public required string Name { get; set; }
	public int GameCount { get; set; }
	public double AverageAttempts { get; set; }
	public double AverageSeconds { get; set; }
}
