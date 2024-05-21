using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wordle.Api.Models
{
    [Table("Players")]
    public class Player
    {
        public int PlayerId { get; set; }
        public string? Name { get; set; } = null;
        public int GameCount { get; set; }
        public double AverageAttempts { get; set; }
        public double AverageSecondsPerGame { get; set; }
    }
}
