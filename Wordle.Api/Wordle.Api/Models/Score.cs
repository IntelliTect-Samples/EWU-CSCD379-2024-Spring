using System.ComponentModel.DataAnnotations.Schema;

namespace Wordle.Api.Models;

[Table("Scores")]
public class Score
{
    public int ScoreId { get; set; }
    public int PlayerId { get; set; }
    public double AverageGuesses { get; set; }
    public int GamesPlayed { get; set; }
}