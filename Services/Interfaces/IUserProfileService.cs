using SocialMediaPlatformBackend.Data.DTO;
using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Services.Interfaces
{
    public interface IUserProfileService
    {
        public Task<Models.Profile> GetByUserIdAsync(Models.User user);
        public Task<Models.Profile> AddUserWithProfile(Models.User user);
    }
}
