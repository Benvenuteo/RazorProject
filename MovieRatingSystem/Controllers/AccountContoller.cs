using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieRatingSystem.Application.DTOs;
using MovieRatingSystem.Application.Services;
using MovieRatingSystem.Domain.Entities;

namespace MovieRatingSystem.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly AuthService _authService;

    public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, AuthService authService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _authService = authService;
    }

    [HttpGet]
    public IActionResult Login(string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginInput model, string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;

        // Walidacja tylko Email i Password
        if (!string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.Password))
        {
            var result = await _authService.LoginAsync(model);
            if (result.Success)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl ?? "/");
                }
            }
            else
            {
                ModelState.AddModelError("", string.Join(", ", result.Errors));
            }
        }
        else
        {
            ModelState.AddModelError("", "Email and Password are required.");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Register(string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(LoginInput model, string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;

        // Ręczna walidacja Email i Password
        if (!string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.Password))
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                TempData["SuccessMessage"] = "Zarejestrowano pomyślnie!";
                return RedirectToAction("Login", new { returnUrl });
            }
            // Przekazanie szczegółowych błędów do widoku
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        else
        {
            ModelState.AddModelError("", "Email and Password are required.");
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    [Authorize]
    public IActionResult Profile()
    {
        return View();
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}