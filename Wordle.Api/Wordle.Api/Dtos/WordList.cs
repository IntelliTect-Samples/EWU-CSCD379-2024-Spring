namespace Wordle.Api.Dtos
{
  public class WordList{
    public int Total { get; set; }
    public List<WordsDto> Words { get; set; } = [];
  }
}
