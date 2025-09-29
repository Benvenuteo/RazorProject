using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRatingSystem.Application.Services;
using MovieRatingSystem.Domain.Entities;

namespace MovieRatingSystem.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MediaService _mediaService;
        private readonly UserActionService _userActionService;

        public MoviesController(MediaService mediaService, UserActionService userActionService)
        {
            _mediaService = mediaService;
            _userActionService = userActionService;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _mediaService.GetAllMoviesAsync();
            return View(movies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _mediaService.GetMovieByIdAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Rate(int id, int score)
        {
            var userId = User.Identity.Name;
            await _userActionService.AddRatingAsync(new Rating { UserId = userId, MediaId = id, Score = score });
            return RedirectToAction("Details", new { id });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToFavorites(int id)
        {
            var userId = User.Identity.Name;
            await _userActionService.AddToListAsync(userId, id, Domain.Enums.ListType.Favorites);
            return RedirectToAction("Details", new { id });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToWatchlist(int id)
        {
            var userId = User.Identity.Name;
            await _userActionService.AddToListAsync(userId, id, Domain.Enums.ListType.Watchlist);
            return RedirectToAction("Details", new { id });
        }
    }
}
