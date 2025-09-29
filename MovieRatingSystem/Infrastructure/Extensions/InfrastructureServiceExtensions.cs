using Microsoft.EntityFrameworkCore;
using MovieRatingSystem.Infrastructure.Data;
using MovieRatingSystem.Infrastructure.Repositories;

namespace MovieRatingSystem.Infrastructure.Extensions
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieRatingDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IMediaRepository, MediaRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IUserListRepository, UserListRepository>();

            return services;
        }
    }
}
