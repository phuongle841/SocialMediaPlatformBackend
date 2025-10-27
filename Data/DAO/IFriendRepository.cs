using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Data.DAO
{
    public interface IFriendRepository
    {
        Task<IEnumerable<Friend>> GetAll();
        Task<Friend> GetById(int id);
        Task<Friend> Add(Friend user, Friend friend);
        Task<Friend> Update(Friend user, Friend friend);
        Task<Friend> Delete(Friend user, Friend friend);
    }
}
