namespace Wordle.Api.Dtos;

public class WordListDto
{
    public int Count { get; set; }
    public List<WordDto> Items { get; set; } = [];

}

