using SocialMediaPlatformBackend.Data.DAO;
using SocialMediaPlatformBackend.Models;
using SocialMediaPlatformBackend.Services.Interfaces;

namespace SocialMediaPlatformBackend.Services.Implement
{
    public class ProfileService : IProfileService
    {
        private readonly ILogger<ProfileService> _logger;
        private readonly IProfileRepository _profileRepository;
        public ProfileService(ILogger<ProfileService> logger, IProfileRepository profileRepository)
        {
            _logger = logger;
            _profileRepository = profileRepository;
        }

        public Task DeleteAsync(int profileId)
        {
            throw new NotImplementedException();
        }

        public Task<Profile> getAllAsync(int profileId)
        {
            throw new NotImplementedException();
        }

        public async Task<Profile> getByIdAsync(int profileId)
        {
            Profile profile = await _profileRepository.GetById(profileId);
            return profile;
        }

        public Task UpdateAsync(int profileId, Profile profile)
        {

            throw new NotImplementedException();
        }
    }
}
