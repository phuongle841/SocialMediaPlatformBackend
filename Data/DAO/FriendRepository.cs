using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Data.DAO
{
    public class FriendRepository : IFriendRepository
    {
        public Task<Friend> Add(Friend user, Friend friend)
        {
            throw new NotImplementedException();
        }

        public Task<Friend> Delete(Friend user, Friend friend)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Friend>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Friend> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Friend> Update(Friend user, Friend friend)
        {
            throw new NotImplementedException();
        }
    }
}
