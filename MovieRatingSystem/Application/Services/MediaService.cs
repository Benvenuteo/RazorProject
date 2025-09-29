using MovieRatingSystem.Domain.Entities;
using MovieRatingSystem.Infrastructure.Repositories;

namespace MovieRatingSystem.Application.Services
{
    public class MediaService
    {
        private readonly IMediaRepository _mediaRepository;

        public MediaService(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        public async Task AddMediaAsync(Media media)
        {
            await _mediaRepository.AddAsync(media);
        }

        public async Task DeleteMediaAsync(int id, Domain.Enums.MediaType type)
        {
            await _mediaRepository.DeleteAsync(id, type);
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _mediaRepository.GetAllMoviesAsync();
        }

        public async Task<List<TvShow>> GetAllTvShowsAsync()
        {
            return await _mediaRepository.GetAllTvShowsAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _mediaRepository.GetMovieByIdAsync(id);
        }

        public async Task<TvShow> GetTvShowByIdAsync(int id)
        {
            return await _mediaRepository.GetTvShowByIdAsync(id);
        }
    }
}
