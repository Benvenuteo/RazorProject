using MovieRatingSystem.Domain.Entities;

namespace MovieRatingSystem.Infrastructure.Repositories
{
    public interface IRatingRepository
    {
        Task AddAsync(Rating rating);
    }
}
