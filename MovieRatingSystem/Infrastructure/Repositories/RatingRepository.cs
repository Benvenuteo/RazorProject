using MovieRatingSystem.Domain.Entities;
using MovieRatingSystem.Infrastructure.Data;

namespace MovieRatingSystem.Infrastructure.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly MovieRatingDbContext _context;

        public RatingRepository(MovieRatingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Rating rating)
        {
            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();
        }
    }
}
