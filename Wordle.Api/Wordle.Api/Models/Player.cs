using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Models;

public class Player
{
    public int PlayerId { get; set; }
    [Required]
    public required string Name { get; set; }
    public int GameCount { get; set; }
    public double AverageAttempts { get; set; }
    public double AverageSeconds { get; set; }
}
