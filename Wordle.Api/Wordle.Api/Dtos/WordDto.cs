namespace Wordle.Api.Dtos
{
    public class WordDto
    {

        public string Word { get; set; } = null!;
        public bool IsCommon { get; set; }
    }
}