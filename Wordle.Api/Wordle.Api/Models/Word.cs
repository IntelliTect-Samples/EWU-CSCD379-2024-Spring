using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Models;
public class Word
{
    public int WordId { get; set; }

    public bool IsCommon { get; set; } = true;

    [Required]
    public required string Text { get; set; }

    public ICollection<Game> Games { get; set; } = [];
    public ICollection<WordOfTheDay> WordsOfTheDays { get; set; } = [];
}
