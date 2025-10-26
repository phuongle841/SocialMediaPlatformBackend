using Microsoft.AspNetCore.Identity;

namespace SocialMediaPlatformBackend.Models
{
    public class User : IdentityUser
    {
        Profile profile { get; set; }
        Message message { get; set; }
    }
}
