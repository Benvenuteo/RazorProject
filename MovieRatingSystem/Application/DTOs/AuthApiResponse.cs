namespace MovieRatingSystem.Application.DTOs
{
    public class AuthApiResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string UserId { get; set; }
    }
}
