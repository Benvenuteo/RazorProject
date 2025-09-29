using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieRatingSystem.Application.Services;
using MovieRatingSystem.Domain.Entities;
using MovieRatingSystem.Domain.Enums;

namespace MovieRatingSystem.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserActionService _userActionService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserActionService userActionService, UserManager<ApplicationUser> userManager)
        {
            _userActionService = userActionService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Watchlist()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Account");

            var watchlist = await _userActionService.GetUserListsAsync(user.Email, ListType.Watchlist);
            ViewBag.WatchlistItems = watchlist;
            return View();
        }

        public async Task<IActionResult> Favorites()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Account");

            var favorites = await _userActionService.GetUserListsAsync(user.Email, ListType.Favorites);
            ViewBag.FavoriteItems = favorites;
            return View();
        }
    }
}