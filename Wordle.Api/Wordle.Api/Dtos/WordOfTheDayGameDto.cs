namespace Wordle.Api.Dtos
{
    public class WordOfTheDayGameDto
    {
        public int Attempts { get; set; }

        public bool IsWin { get; set; }

        public required string WordOfTheDay {  get; set; }
    }
}
