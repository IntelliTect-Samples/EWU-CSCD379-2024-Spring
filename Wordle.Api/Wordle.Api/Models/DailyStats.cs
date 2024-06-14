namespace Wordle.Api.Models
{
    public class DailyStats
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int NumberOfPlays { get; set; }
        public double AverageScore { get; set; }
        public double AverageSecondsPerGame { get; set; }
        public bool UserHasPlayed { get; set; }
    }
}
