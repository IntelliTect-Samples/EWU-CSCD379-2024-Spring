namespace Wordle.Api.Dtos
{
    public class GameStatsDto
    {
        public string? Word { get; set; }

        public DateOnly Date { get; set; }

        public double AverageGuesses { get; set; } = 0;

        public double AverageTime { get; set; } = 0;

        public int TotalTimesPlayed { get; set; } = 0;

        public int TotalWins { get; set; } = 0;

        public int TotalLosses { get => TotalTimesPlayed - TotalWins; }

        public bool Played { get; set; } = false;
    }
}
