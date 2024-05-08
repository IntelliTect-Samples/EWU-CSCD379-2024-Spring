namespace Wordle.Api.Dtos
{
    public class PlayerDto
    {
        public string Name { get; set; } = null!;
        public int GameCount { get; set; }
        public double AverageAttempts { get; set; }
    }
}
