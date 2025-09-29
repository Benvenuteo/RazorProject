namespace MovieRatingSystem.Infrastructure.Middleware
{
    public class JwtCookieSyncMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtCookieSyncMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Cookies[".MovieRating.Auth"];
            if (!string.IsNullOrEmpty(token))
            {
                context.Items["JwtToken"] = token;
            }
            await _next(context);
        }
    }
}
