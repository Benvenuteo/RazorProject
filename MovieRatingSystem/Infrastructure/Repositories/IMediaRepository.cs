using MovieRatingSystem.Domain.Entities;
using MovieRatingSystem.Domain.Enums;

namespace MovieRatingSystem.Infrastructure.Repositories
{
    public interface IMediaRepository
    {
        Task AddAsync(Media media);
        Task DeleteAsync(int id, MediaType type);
        Task<List<Movie>> GetAllMoviesAsync();
        Task<List<TvShow>> GetAllTvShowsAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task<TvShow> GetTvShowByIdAsync(int id);
    }
}
