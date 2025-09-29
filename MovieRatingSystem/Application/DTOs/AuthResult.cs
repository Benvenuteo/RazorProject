namespace MovieRatingSystem.Application.DTOs
{
    public class AuthResult
    {
        public bool Success { get; set; }
        public string[] Errors { get; set; }
        public string Token { get; set; }
    }
}
