namespace Wordle.Api.Dtos;

public class GameDto
{
    public string PlayerName { get; set; } = null!;
    public int Attempts { get; set; }
    public bool IsWin { get; set; }
    public required string Word { get; set; }
}