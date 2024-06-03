namespace Wordle.Api.Dtos
{
    public record ScoreDto
    {
        public string PlayerName { get; set; } = "";
        public int Attempts { get; set; }
        public double Time { get; set; }
    }
}
