using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Services
{
    public interface IJwtService
    {
        Task<string> GenerateToken(User user);
    }
}
