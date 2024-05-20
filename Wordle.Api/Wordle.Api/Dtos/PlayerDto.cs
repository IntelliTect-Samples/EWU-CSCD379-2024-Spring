using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Dtos;


public record PlayerDto
{
    [Required]
    [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [Range(0, int.MaxValue, ErrorMessage = "Game count must be non-negative.")]
    public int GameCount { get; set; }

    [Range(0.0, double.MaxValue, ErrorMessage = "Average attempts must be non-negative.")]
    public double AverageAttempts { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Average seconds per game must be non-negative.")]
    public int AverageSecondsPerGame { get; set; }
}
