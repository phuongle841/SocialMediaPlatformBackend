namespace SocialMediaPlatformBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public int ProfileId { get; set; }
    }
}
