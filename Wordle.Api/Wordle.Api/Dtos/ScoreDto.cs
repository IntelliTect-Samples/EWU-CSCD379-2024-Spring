namespace Wordle.Api.Models
{
    public record ScoreDto
    {
        public string PlayerName { get; set; } = "";
        public int Attempts { get; set; }
        public int Time { get; set; }
    }
}
