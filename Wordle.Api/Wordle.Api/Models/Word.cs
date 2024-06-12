using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Models
{
    public class Word
    {
    public int WordId { get; set; }
    public string Text { get; set; } = null!;
    public bool IsCommon { get; set; }
    
    public ICollection<Game> Games { get; set; } = new List<Game>();
    public ICollection<WordOfTheDay> WordsOfTheDays { get; set; } = new List<WordOfTheDay>();
    }
}
