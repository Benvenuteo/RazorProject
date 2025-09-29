using Microsoft.AspNetCore.Mvc;
using MovieRatingSystem.Application.DTOs;
using MovieRatingSystem.Application.Services;

namespace MovieRatingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthApiRequest model)
        {
            var result = await _authService.LoginAsync(new LoginInput { Email = model.Email, Password = model.Password });
            if (result.Success)
                return Ok(new AuthApiResponse { Token = result.Token });
            return Unauthorized(new { errors = result.Errors });
        }
    }
}
