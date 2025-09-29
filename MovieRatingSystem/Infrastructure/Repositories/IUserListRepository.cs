using MovieRatingSystem.Domain.Entities;
using MovieRatingSystem.Domain.Enums;

namespace MovieRatingSystem.Infrastructure.Repositories
{
    public interface IUserListRepository
    {
        Task AddAsync(UserList userList);
        Task<List<Media>> GetByUserAndTypeAsync(string userId, ListType listType);
    }
}
