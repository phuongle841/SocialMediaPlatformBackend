using Microsoft.EntityFrameworkCore;
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

        public async Task<Friend> Add(Profile user, Profile friend)
        {
            var friendEntity = new Friend
            {
                Follower = user,
                Following = friend,
                CreateAt = DateTime.UtcNow,
                Status = FriendStatus.Pending
            };
            await _context.Friends.AddAsync(friendEntity);
            _context.SaveChanges();
            return friendEntity;
        }

        public async Task<Friend> Delete(Profile user, Profile friend)
        {
            Friend DeletedRelationShip = await GetById(user, friend);

            _context.Entry(DeletedRelationShip).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
            return DeletedRelationShip;
        }

        public async Task<IEnumerable<Friend>> GetAll(Profile user)
        {
            IEnumerable<Friend> allRelationship = await _context.Friends.ToListAsync();
            var detailedRelationships = allRelationship
                .Select(fr => new Friend
                {
                    Id = fr.Id,
                    Follower = _context.Profiles.Find(fr.Follower.Username)!,
                    Following = _context.Profiles.Find(fr.Following.Username)!,
                    CreateAt = fr.CreateAt,
                    Status = fr.Status
                });
            return detailedRelationships;
        }

        public async Task<Friend> GetById(Profile user, Profile friend)
        {
            IEnumerable<Friend> allRelationship = await _context.Friends.ToListAsync();
            Friend relationship = allRelationship
                                .Where(fr => fr.Follower.Username == user.Username && fr.Following.Username == friend.Username)
                                .First();
            return relationship;
        }

        public async Task<Friend> Update(Profile user, Profile friend, FriendStatus status)
        {
            Friend updateRelationShip = await GetById(user, friend);
            if (updateRelationShip != null)
            {
                updateRelationShip.Status = status;
                _context.Entry(updateRelationShip).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return updateRelationShip;
            }
            return null;
        }
    }
}
