namespace MovieRatingSystem.Application.DTOs
{
    public class LoginInput
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
