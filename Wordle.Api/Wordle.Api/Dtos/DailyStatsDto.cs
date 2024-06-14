namespace Wordle.Api.Dtos
{
    public class DailyStatsDto
    {
        public int NumberOfPlays { get; set; }
        public double AverageScore { get; set; }
        public double AverageSecondsPerGame { get; set; }
        public bool UserHasPlayed { get; set; }
    }
}
