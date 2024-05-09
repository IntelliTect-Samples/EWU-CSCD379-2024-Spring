namespace Wordle.Api.Models
{
    public class Score
    {
        public string Name { get; set; } = null!;
        public int Attempts { get; set; }
        public int Seconds { get; set; }
    }
}
