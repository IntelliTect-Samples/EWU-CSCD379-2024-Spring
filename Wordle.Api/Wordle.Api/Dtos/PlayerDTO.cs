namespace Wordle.Api.Dtos;

public record PlayerDTO{
  public string Name { get; set; }
  public int GameCount { get; set; }
  public double AverageAttempts { get; set; }
  public int AverageSecondsPerGame {get; set; }
}