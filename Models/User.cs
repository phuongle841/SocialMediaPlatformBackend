using Microsoft.AspNetCore.Identity;

namespace SocialMediaPlatformBackend.Models
{
    public class User : IdentityUser
    {
        public Profile? profile { get; set; }
    }
}
