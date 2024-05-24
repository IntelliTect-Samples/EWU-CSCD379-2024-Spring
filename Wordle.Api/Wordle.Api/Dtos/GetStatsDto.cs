using Wordle.Api.Models;

namespace Wordle.Api.Dtos
{
    public class GetStatsDto
    {
        public DateTime Date { get; set; }

        public string? PlayerName { get; set; }
    }
}
