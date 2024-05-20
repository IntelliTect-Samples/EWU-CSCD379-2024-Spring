namespace Wordle.Api.Models
{
    public record PlayerDto
    {
        public string Name { get; set; } = "";
        public double AverageAttempts { get; set; }
        public int AverageTime { get; set; }
        public int GameCount { get; set; }
    }
}
