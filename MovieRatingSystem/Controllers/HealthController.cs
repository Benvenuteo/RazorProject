using Microsoft.AspNetCore.Mvc;

namespace MovieRatingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Check()
        {
            return Ok("Healthy");
        }
    }
}
