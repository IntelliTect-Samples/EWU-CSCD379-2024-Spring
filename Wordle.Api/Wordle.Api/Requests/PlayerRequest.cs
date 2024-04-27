namespace Wordle.Api.Requests;

public class PlayerRequest
{
	public int? PlayerId { get; set; }
	public string Name { get; set; }
	public int GameCount { get; set; }
	public double AverageAttempts { get; set; }
}
