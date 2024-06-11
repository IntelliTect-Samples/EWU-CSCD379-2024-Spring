namespace Wordle.Api.Dtos
{
    public class NewWordDto
    {
        public int Count { get; set; }
        public List<WordDto> Items { get; set; } = new();
    }
}
