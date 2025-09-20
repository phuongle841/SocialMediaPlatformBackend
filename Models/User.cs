namespace SocialMediaPlatformBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string HashedPassword { get; set; }
        public required int ProfileId { get; set; }
    }
}
