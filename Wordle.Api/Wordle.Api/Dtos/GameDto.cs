using System.ComponentModel.DataAnnotations;
using Wordle.Api.Models;

namespace Wordle.Api.Dtos
{
    public class GameDto
    {
        [Required]
        public required string Name { get; set; }
        public int Attempts { get; set; }

        public int Seconds { get; set; }

        public bool IsWin { get; set; }

        public required string Word {  get; set; }
    }
}
