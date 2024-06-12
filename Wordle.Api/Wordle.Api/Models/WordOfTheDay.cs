using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wordle.Api.Models;
    [Table("WordOfTheDay")]
    public class WordOfTheDay
    {
    public int WordOfTheDayId { get; set; }
    public DateOnly Date { get; set; }
    public int WordId { get; set; }

    public Word Word { get; set; } = null!;
    public ICollection<Game> Games { get; set; } = new List<Game>();
    }