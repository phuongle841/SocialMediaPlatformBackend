using SocialMediaPlatformBackend.Data.DAO;
using SocialMediaPlatformBackend.Models;
using SocialMediaPlatformBackend.Services.Interfaces;

namespace SocialMediaPlatformBackend.Services.Implement
{
    public class FriendService : IFriendService
    {
        private readonly ILogger<FriendService> _logger;
        private readonly IFriendRepository _friendRepository;
        private readonly IProfileService _profileService;

        public FriendService(IFriendRepository friendRepository, ILogger<FriendService> logger, IProfileService profileService)
        {
            _friendRepository = friendRepository;
            _logger = logger;
            _profileService = profileService;
        }

        public async Task<Friend> AddAsync(int userId, int friendId)
        {
            Profile user = await _profileService.getByIdAsync(userId);
            Profile friend = await _profileService.getByIdAsync(friendId);
            Friend relationship = await _friendRepository.Add(user, friend);
            return relationship;
        }

        public async Task<Friend> DeleteAsync(int userId, int friendId)
        {
            Profile user = await _profileService.getByIdAsync(userId);
            Profile friend = await _profileService.getByIdAsync(friendId);
            Friend deletedRelationship = await _friendRepository.Delete(user, friend);
            return deletedRelationship;
        }

        public async Task<IEnumerable<Friend>> GetAllAsync(int userId)
        {
            Profile user = await _profileService.getByIdAsync(userId);
            IEnumerable<Friend> relationships = await _friendRepository.GetAll(user);
            return relationships;
        }

        public async Task<Friend> GetById(int userId, int friendId)
        {
            Profile user = await _profileService.getByIdAsync(userId);
            Profile friend = await _profileService.getByIdAsync(friendId);
            Friend relationship = await _friendRepository.GetById(user, friend);
            return relationship;
        }

        public async Task<Friend> UpdateAsync(int userId, int friendId, FriendStatus status)
        {
            Profile user = await _profileService.getByIdAsync(userId);
            Profile friend = await _profileService.getByIdAsync(friendId);
            Friend updatedRelationship = await _friendRepository.Update(user, friend, status);
            return updatedRelationship;
        }
    }
}
