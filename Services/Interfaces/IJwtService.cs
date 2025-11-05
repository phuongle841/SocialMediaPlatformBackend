using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Services.Interfaces
{
    public interface IJwtService
    {
        Task<string> GenerateToken(User user);
    }
}
