namespace Wordle.Api.Models
{
    public record Score
    {
        public string Name { get; set; } = "";
        public double AverageAttempts { get; set; }
        public int GameCount { get; set; }
    }
}
