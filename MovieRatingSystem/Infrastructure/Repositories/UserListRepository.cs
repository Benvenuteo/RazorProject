using Microsoft.EntityFrameworkCore;
using MovieRatingSystem.Domain.Entities;
using MovieRatingSystem.Domain.Enums;
using MovieRatingSystem.Infrastructure.Data;

namespace MovieRatingSystem.Infrastructure.Repositories
{
    public class UserListRepository : IUserListRepository
    {
        private readonly MovieRatingDbContext _context;

        public UserListRepository(MovieRatingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserList userList)
        {
            await _context.UserLists.AddAsync(userList);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Media>> GetByUserAndTypeAsync(string userId, ListType listType)
        {
            var mediaIds = await _context.UserLists
                .Where(ul => ul.UserId == userId && ul.ListType == listType)
                .Select(ul => ul.MediaId)
                .ToListAsync();

            var movies = await _context.Movies.Where(m => mediaIds.Contains(m.Id)).ToListAsync();
            var tvShows = await _context.TvShows.Where(m => mediaIds.Contains(m.Id)).ToListAsync();
            return movies.Cast<Media>().Concat(tvShows).ToList();
        }
    }
}
