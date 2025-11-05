using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Services.Interfaces
{
    public interface IProfileService
    {
        public Task<Profile> getAllAsync(int profileId);
        public Task<Profile> getByIdAsync(int profileId);
        public Task UpdateAsync(int profileId, Profile profile);
        public Task DeleteAsync(int profileId);
    }
}
