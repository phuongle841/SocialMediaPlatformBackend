using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Services.Interfaces
{
    public interface IFriendService
    {
        public Task<IEnumerable<Relationship>> GetAllAsync(int userId);
        public Task<Relationship> GetById(int userId, int friendId);
        public Task<Relationship?> AddAsync(int userId, int friendId, FriendStatus status);
        public Task<Relationship> UpdateAsync(int userId, int friendId, FriendStatus status);
        public Task<Relationship> DeleteAsync(int userId, int friendId);
    }
}
