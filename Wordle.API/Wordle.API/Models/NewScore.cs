namespace Wordle.Api.Models
{
    public record NewScore
    {
        public string playerName { get; set; } = "";
        public int attempts { get; set; }
        public int time { get; set; }
    }
}
