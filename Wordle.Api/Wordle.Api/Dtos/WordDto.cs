namespace Wordle.Api.Dtos;

public class WordDto
{
    public required string Word { get; set; }
    public required bool IsCommonWord { get; set; }
}
