using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wordle.Api.Models;
    [Table("WordOfTheDay")]
    public class WordOfTheDay
    {
        public int WordOfTheDayId { get; set; }

        [Required]
        public int WordId { get; set; }
        public Word? Word { get; set; }
        
        public DateOnly Date { get; set; }

        public ICollection<Game> Games { get; set; } = [];
    }
