using Microsoft.EntityFrameworkCore;
using MovieRatingSystem.Domain.Entities;
using MovieRatingSystem.Domain.Enums;
using MovieRatingSystem.Infrastructure.Data;

namespace MovieRatingSystem.Infrastructure.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        private readonly MovieRatingDbContext _context;

        public MediaRepository(MovieRatingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Media media)
        {
            await _context.AddAsync(media);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, MediaType type)
        {
            var entity = type == MediaType.Movie
                ? await _context.Movies.FindAsync(id) as Media
                : await _context.TvShows.FindAsync(id);
            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<List<TvShow>> GetAllTvShowsAsync()
        {
            return await _context.TvShows.ToListAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<TvShow> GetTvShowByIdAsync(int id)
        {
            return await _context.TvShows.FindAsync(id);
        }
    }
}
