using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wordle.Api.Models
{
    [Table("WordOfTheDay")]
    public class WordOfTheDay
    {
        public int WordOfTheDayId { get; set; }
        public string Word { get; set; } = null!;
        public DateOnly Date { get; set; }
        
    }
}
