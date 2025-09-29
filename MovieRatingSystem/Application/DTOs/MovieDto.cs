namespace MovieRatingSystem.Application.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public decimal Rating { get; set; }
    }
}
