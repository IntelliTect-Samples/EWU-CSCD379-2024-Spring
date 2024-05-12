namespace Wordle.Api.Dtos
{
    public class WordStatsDto
    {
        public DateOnly Date { get; set; }
        public double AverageAttempts { get; set; }
        public double TotalGamesPlayed { get; set; }
        public int NumberOfWins { get; set; }

        public List<GameDto> Games { get; set; } = [];
    }
}
