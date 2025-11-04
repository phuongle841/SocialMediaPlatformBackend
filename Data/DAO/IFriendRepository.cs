using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Data.DAO
{
    public interface IFriendRepository
    {
        Task<IEnumerable<Friend>> GetAll(Profile user);
        Task<Friend> GetById(Profile user, Profile friend);
        Task<Friend> Add(Profile user, Profile friend);
        Task<Friend> Update(Profile user, Profile friend, FriendStatus status);
        Task<Friend> Delete(Profile user, Profile friend);
    }
}
