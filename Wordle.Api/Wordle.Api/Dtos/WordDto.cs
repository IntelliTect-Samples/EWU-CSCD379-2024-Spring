namespace Wordle.Api.Dtos
{
    public class WordDto
    {
        public int Id { get; set; }
        public string Word { get; set; } = null!;
        public bool IsCommon { get; set; }
    }
}