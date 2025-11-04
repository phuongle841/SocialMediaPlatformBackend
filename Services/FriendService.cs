using SocialMediaPlatformBackend.Data.DAO;
using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Services
{
    public class FriendService : IFriendService
    {
        private readonly ILogger<FriendService> _logger;
        private readonly IFriendRepository _friendRepository;

        public FriendService(IFriendRepository friendRepository, ILogger<FriendService> logger)
        {
            _friendRepository = friendRepository;
            _logger = logger;
        }

        public Task AddAsync(Friend userId, Friend friendId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Friend userId, Friend friendId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Friend>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Friend> GetById(int Id)
        {
            var friend = _friendRepository.GetById(Id);
            return friend;
        }

        public Task UpdateAsync(Friend userId, Friend friendId)
        {
            throw new NotImplementedException();
        }
    }
}
