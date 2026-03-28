using Microsoft.EntityFrameworkCore;
using SocialMediaPlatformBackend.Data.DAO.Interfaces;
using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Data.DAO
{
    public class FriendRepository : IFriendRepository
    {
        private readonly ILogger<FriendRepository> _logger;
        private readonly AppDbContext _context;

        public FriendRepository(AppDbContext context, ILogger<FriendRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Friend> Add(Profile user, Profile friend, FriendStatus status)
        {
            var friendEntity = new Friend
            {
                Follower = user,
                Following = friend,
                CreateAt = DateTime.UtcNow,
                Status = status
            };
            await _context.Friends.AddAsync(friendEntity);
            await _context.SaveChangesAsync();
            return friendEntity;
        }

        public async Task<Friend> Delete(Profile user, Profile friend)
        {
            Friend DeletedRelationship = await GetById(user, friend);
            if (DeletedRelationship == null)
            {
                return null;
            }

            _context.Entry(DeletedRelationship).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
            return DeletedRelationship;
        }

        public async Task<IEnumerable<Friend>> GetAll(Profile user)
        {
            IEnumerable<Friend> detailedRelationships = await _context.Friends.Where(f => f.Follower.ProfileId == user.ProfileId).ToListAsync();
            return detailedRelationships;
        }

        public async Task<Friend> GetById(Profile user, Profile friend)
        {
            try
            {
                Friend relationship = await _context.Friends.SingleOrDefaultAsync(e => e.Follower.ProfileId == user.ProfileId && e.Following.ProfileId == friend.ProfileId);
                return relationship;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error fetching friendship");
                return null;
            }

        }

        public async Task<Friend> Update(Profile user, Profile friend, FriendStatus status)
        {
            Friend updateRelationship = await GetById(user, friend);
            if (updateRelationship == null)
            {
                return null;
            }
            updateRelationship.Status = status;
            _context.Entry(updateRelationship).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return updateRelationship;
        }
    }
}
