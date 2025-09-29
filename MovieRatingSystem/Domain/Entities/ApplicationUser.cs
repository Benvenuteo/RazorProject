using Microsoft.AspNetCore.Identity;

namespace MovieRatingSystem.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public int? TotalRatings { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public List<Rating>? Ratings { get; set; }
        public List<UserList>? UserLists { get; set; }
    }
}
