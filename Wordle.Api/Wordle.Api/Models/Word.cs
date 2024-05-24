using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Wordle.Api.Models;

[Index(nameof(Text), IsUnique = true)]
public class Word
{
    public int WordId { get; set; }

    [Required]
    public required string Text { get; set; }

    public ICollection<Game> Games { get; set; } = [];
    public ICollection<WordOfTheDay> WordsOfTheDays { get; set; } = [];
}
