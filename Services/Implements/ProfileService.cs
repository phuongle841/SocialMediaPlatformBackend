using Microsoft.VisualBasic;
using SocialMediaPlatformBackend.Data.DAO.Interfaces;
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

        public async Task<Profile> AddAsync(Profile profile)
        {
            var newProfile = await _profileRepository.Add(profile);
            return newProfile;
        }

        public async Task DeleteAsync(int profileId)
        {
            throw new NotImplementedException();

        }

        public async Task<List<Profile>> GetAllAsync()
        {
            List<Profile> profile = await _profileRepository.GetAll();
            return profile;
        }

        public async Task<Profile> GetByIdAsync(int profileId)
        {
            Profile profile = await _profileRepository.GetById(profileId);
            return profile;
        }

        public async Task<Profile> UpdateAsync(int profileId, Profile profile)
        {
            Profile selectedProfile = await _profileRepository.GetById(profileId);
            return selectedProfile;
        }
    }
}
