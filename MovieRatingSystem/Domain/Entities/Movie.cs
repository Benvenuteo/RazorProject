namespace MovieRatingSystem.Domain.Entities
{
    public class Movie : Media
    {
        public int ReleaseYear { get; set; }
        public decimal Rating { get; set; }
    }
}
