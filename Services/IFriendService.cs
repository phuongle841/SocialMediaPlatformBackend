using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Services
{
    public interface IFriendService
    {
        public Task<IEnumerable<Friend>> GetAllAsync();
        public Task<Friend> GetById(Friend userId, Friend friendId);
        public Task AddAsync(Friend userId, Friend friendId);
        public Task UpdateAsync(Friend userId, Friend friendId);
        public Task DeleteAsync(Friend userId, Friend friendId);
    }
}
