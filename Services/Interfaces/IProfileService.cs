using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Services.Interfaces
{
    public interface IProfileService
    {
        public Task<List<Profile>> GetAllAsync();
        public Task<Profile> GetByIdAsync(int profileId);
        public Task<Profile> AddAsync(Profile profile);
        public Task<Profile> UpdateAsync(int profileId, Profile profile);
        public Task DeleteAsync(int profileId);
    }
}
