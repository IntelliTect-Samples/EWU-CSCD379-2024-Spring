using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Models
{
    public class Word
    {
        public int Id { get; set; }

        [Required]
        public required string Text { get; set; }

        public ICollection<Game> Games { get; set; } = new List<Game>();
        public ICollection<WordOfTheDay> WordsOfTheDays { get; set; } = new List<WordOfTheDay>();

        public bool IsCommon { get; set; } = true;
    }
}
