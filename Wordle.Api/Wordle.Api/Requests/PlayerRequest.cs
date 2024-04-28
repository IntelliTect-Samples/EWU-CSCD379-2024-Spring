namespace Wordle.Api.Requests;

public class PlayerRequest
{
	public string Name { get; set; }
	public int GameCount { get; set; }
	public double Attempts { get; set; }
}
