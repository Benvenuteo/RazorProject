using MovieRatingSystem.Domain.Entities;
using MovieRatingSystem.Domain.Enums;
using MovieRatingSystem.Infrastructure.Repositories;

namespace MovieRatingSystem.Application.Services
{
    public class UserActionService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IUserListRepository _userListRepository;

        public UserActionService(IRatingRepository ratingRepository, IUserListRepository userListRepository)
        {
            _ratingRepository = ratingRepository;
            _userListRepository = userListRepository;
        }

        public async Task AddRatingAsync(Rating rating)
        {
            await _ratingRepository.AddAsync(rating);
        }

        public async Task AddToListAsync(string userId, int mediaId, ListType listType)
        {
            var userList = new UserList { UserId = userId, MediaId = mediaId, ListType = listType };
            await _userListRepository.AddAsync(userList);
        }

        public async Task<List<Media>> GetUserListsAsync(string userId, ListType listType)
        {
            return await _userListRepository.GetByUserAndTypeAsync(userId, listType);
        }
    }
}
