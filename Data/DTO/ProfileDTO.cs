using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Data.DTO
{
    public class ProfileDTO
    {
        public int ProfileId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public string Bio { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
