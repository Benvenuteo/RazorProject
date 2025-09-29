using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRatingSystem.Application.Services;
using MovieRatingSystem.Domain.Entities;
using MovieRatingSystem.Models;

namespace MovieRatingSystem.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class AdminController : Controller
    {
        private readonly MediaService _mediaService;

        public AdminController(MediaService mediaService)
        {
            _mediaService = mediaService;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _mediaService.GetAllMoviesAsync();
            var tvShows = await _mediaService.GetAllTvShowsAsync();
            return View(new AdminIndexViewModel
            {
                Movies = movies,
                TvShows = tvShows
            });
        }

        public IActionResult AddMovie() => View();
        public IActionResult AddTvShow() => View();

        [HttpPost]
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            if (!ModelState.IsValid) return View(movie);
            await _mediaService.AddMediaAsync(movie);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddTvShow(TvShow tvShow)
        {
            if (!ModelState.IsValid) return View(tvShow);
            await _mediaService.AddMediaAsync(tvShow);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _mediaService.DeleteMediaAsync(id, Domain.Enums.MediaType.Movie);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTvShow(int id)
        {
            await _mediaService.DeleteMediaAsync(id, Domain.Enums.MediaType.TvShow);
            return RedirectToAction("Index");
        }
    }
}
