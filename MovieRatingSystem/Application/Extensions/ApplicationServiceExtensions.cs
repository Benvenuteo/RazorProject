using MovieRatingSystem.Application.Services;

namespace MovieRatingSystem.Application.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<AuthService>();
            services.AddScoped<MediaService>();
            services.AddScoped<UserActionService>();
            return services;
        }
    }
}
