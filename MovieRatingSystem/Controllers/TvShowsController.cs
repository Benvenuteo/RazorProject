using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRatingSystem.Application.Services;
using MovieRatingSystem.Domain.Entities;

namespace MovieRatingSystem.Controllers
{
    public class TvShowsController : Controller
    {
        private readonly MediaService _mediaService;
        private readonly UserActionService _userActionService;

        public TvShowsController(MediaService mediaService, UserActionService userActionService)
        {
            _mediaService = mediaService;
            _userActionService = userActionService;
        }

        public async Task<IActionResult> Index()
        {
            var tvShows = await _mediaService.GetAllTvShowsAsync();
            return View(tvShows);
        }

        public async Task<IActionResult> Details(int id)
        {
            var tvShow = await _mediaService.GetTvShowByIdAsync(id);
            if (tvShow == null) return NotFound();
            return View(tvShow);
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
