namespace Wordle.Api.Dtos
{
    public class RegisterDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public required string SecretPhrase { get; set; }
        public required DateTime Birthday { get; set; }
    }
}
