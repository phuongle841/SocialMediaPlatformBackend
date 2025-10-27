using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Services
{
    public class FriendService : IFriendService
    {
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

        public Task<Friend> GetById(Friend userId, Friend friendId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Friend userId, Friend friendId)
        {
            throw new NotImplementedException();
        }
    }
}
