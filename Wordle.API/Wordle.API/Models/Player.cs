using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wordle.Api.Models
{
    [Table("Player")]
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; } = "";
        public int GameCount { get; set; }
        public double AverageAttempts { get; set; }
        public int AverageSecondsPerGame { get; set; }
    }
}
