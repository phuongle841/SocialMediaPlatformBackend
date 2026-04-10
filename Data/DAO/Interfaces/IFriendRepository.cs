using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Data.DAO.Interfaces
{
    public interface IFriendRepository
    {
        Task<IEnumerable<Relationship>> GetAll(Profile user);
        Task<Relationship> GetById(Profile user, Profile friend);
        Task<Relationship> Add(Profile user, Profile friend, FriendStatus status);
        Task<Relationship> Update(Profile user, Profile friend, FriendStatus status);
        Task<Relationship> Delete(Profile user, Profile friend);
    }
}
