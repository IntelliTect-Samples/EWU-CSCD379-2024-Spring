using Wordle.Api.Models;

namespace Wordle.Api.Dtos;

public class MoreWordsDto
{
    public List<Word>? Words { get; set; }
    public int Pages { get; set; }
}
