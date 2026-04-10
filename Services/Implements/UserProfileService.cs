using SocialMediaPlatformBackend.Models;
using SocialMediaPlatformBackend.Services.Interfaces;

namespace SocialMediaPlatformBackend.Services.Implements
{
    public class UserProfileService : IUserProfileService
    {
        private readonly ILogger<UserProfileService> _logger;
        private readonly IProfileService _profileService;

        public UserProfileService(IProfileService profileService, ILogger<UserProfileService> logger)
        {
            _profileService = profileService;
            _logger = logger;
        }

        public async Task<Profile> AddUserWithProfile(Models.User user)
        {
            Profile profile = new Profile
            {
                Username = user.UserName,
                Email = user.Email,
                FirstName = "FirstName", // You can set this based on your requirements
                LastName = "LastName",   // You can set this based on your requirements
                DateOfBirth = DateTime.Now, // You can set this based on your requirements
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true,
                LastLogin = DateTime.Now,
            };

            Profile result = await _profileService.AddAsync(profile);
            return profile;
        }

        public Task<Profile> GetByUserIdAsync(Models.User user)
        {
            throw new NotImplementedException();
        }
    }
}
