namespace Wordle.Api.Models
{
    public class WordOfTheDay
    {
        public int WordOfTheDayId { get; set; }
        public string Word { get; set; } = null!;
        public DateOnly Date { get; set; }
    }
}
