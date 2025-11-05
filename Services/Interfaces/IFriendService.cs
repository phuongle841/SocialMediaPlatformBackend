using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Services.Interfaces
{
    public interface IFriendService
    {
        public Task<IEnumerable<Friend>> GetAllAsync(int userId);
        public Task<Friend> GetById(int userId, int friendId);
        public Task<Friend> AddAsync(int userId, int friendId);
        public Task<Friend> UpdateAsync(int userId, int friendId, FriendStatus status);
        public Task<Friend> DeleteAsync(int userId, int friendId);
    }
}
