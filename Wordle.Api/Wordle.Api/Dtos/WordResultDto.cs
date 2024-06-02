namespace Wordle.Api.Dtos;

public class WordResultDto
{
    public int Count { get; set; }
    public List<WordDto> Items { get; set; } = [];

}

