namespace Wordle.Api.Dtos
{
    public class GameStatsDto
    {
        public string? Word { get; set; }

        public DateOnly? Date { get; set; }

        public double AverageGuesses { get; set; }

        public int TotalTimesPlayed { get; set; }

        public double AverageSeconds { get; set; }

        public int TotalWins { get; set; }

        public int TotalLosses { get => TotalTimesPlayed - TotalWins; }

        public List<string> Usernames { get; set; } = [];
    }
}
