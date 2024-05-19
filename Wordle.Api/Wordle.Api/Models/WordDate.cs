using System.ComponentModel.DataAnnotations.Schema;

namespace Wordle.Api.Models;

[Table("WordDates")]
public class WordDate
{
    public int WordDateId { get; set; }
    public string Date {get; set; }
    public int GameCount { get; set; }
    public double AverageAttempts { get; set; }
    public int AverageSecondsPerGame { get; set; }
    public Array PlayerList{ get; set; }
}