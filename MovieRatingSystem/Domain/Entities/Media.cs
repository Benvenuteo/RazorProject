namespace MovieRatingSystem.Domain.Entities
{
    public abstract class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Domain.Enums.MediaType Type { get; set; }
    }
}
