using Microsoft.AspNetCore.Mvc;
using MovieRatingSystem.Application.DTOs;
using MovieRatingSystem.Application.Services;

namespace MovieRatingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly MediaService _mediaService;

        public MediaController(MediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpGet("movies")]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _mediaService.GetAllMoviesAsync();
            return Ok(movies.Select(m => new MovieDto
            {
                Id = m.Id,
                Title = m.Title,
                ReleaseYear = m.ReleaseYear,
                Rating = m.Rating
            }));
        }
    }
}
