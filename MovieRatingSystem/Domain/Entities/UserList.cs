using MovieRatingSystem.Domain.Enums;

namespace MovieRatingSystem.Domain.Entities
{
    public class UserList
    {
        public string UserId { get; set; }
        public int MediaId { get; set; }
        public ListType ListType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
