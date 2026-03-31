using SocialMediaPlatformBackend.Data.DAO.Interfaces;
using SocialMediaPlatformBackend.Models;
using SocialMediaPlatformBackend.Services.Interfaces;

namespace SocialMediaPlatformBackend.Services.Implement
{
    public class FriendService : IFriendService
    {
        private readonly ILogger<FriendService> _logger;
        private readonly IFriendRepository _friendRepository;
        private readonly IProfileService _profileService;
        //TODO: try catch null exception
        public FriendService(IFriendRepository friendRepository, ILogger<FriendService> logger, IProfileService profileService)
        {
            _friendRepository = friendRepository;
            _logger = logger;
            _profileService = profileService;
        }

        public async Task<Relationship> AddAsync(int userId, int friendId, FriendStatus status)
        {
            Profile user = await _profileService.GetByIdAsync(userId);
            Profile friend = await _profileService.GetByIdAsync(friendId);
            Relationship relationship = await _friendRepository.Add(user, friend, status);
            return relationship;
        }

        public async Task<Relationship> DeleteAsync(int userId, int friendId)
        {
            Profile user = await _profileService.GetByIdAsync(userId);
            Profile friend = await _profileService.GetByIdAsync(friendId);
            Relationship deletedRelationship = await _friendRepository.Delete(user, friend);
            return deletedRelationship;
        }

        public async Task<IEnumerable<Relationship>> GetAllAsync(int userId)
        {
            Profile user = await _profileService.GetByIdAsync(userId);
            IEnumerable<Relationship> relationships = await _friendRepository.GetAll(user);
            return relationships;
        }

        public async Task<Relationship?> GetById(int userId, int friendId)
        {
            Profile user = await _profileService.GetByIdAsync(userId);
            Profile friend = await _profileService.GetByIdAsync(friendId);
            if (user == null || friend == null)
            {
                _logger.LogWarning("Cannot add friendship: one or both profiles not found. UserId={UserId}, FriendId={FriendId}", userId, friendId);
                return null;
            }
            Relationship relationship = await _friendRepository.GetById(user, friend);
            return relationship;
        }

        public async Task<Relationship> UpdateAsync(int userId, int friendId, FriendStatus status)
        {
            Profile user = await _profileService.GetByIdAsync(userId);
            Profile friend = await _profileService.GetByIdAsync(friendId);
            if (user == null || friend == null)
            {
                _logger.LogWarning("Cannot delete relationship: one or both profiles not found. UserId={UserId}, FriendId={FriendId}", userId, friendId);
                return null;
            }
            Relationship updatedRelationship = await _friendRepository.Update(user, friend, status);
            return updatedRelationship;
        }
    }
}
