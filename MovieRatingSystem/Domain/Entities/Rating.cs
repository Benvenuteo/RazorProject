namespace MovieRatingSystem.Domain.Entities
{
    public class Rating
    {
        public string UserId { get; set; }
        public int MediaId { get; set; }
        public int Score { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
