namespace SocialMediaPlatformBackend.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Bio { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastLogin { get; set; }
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}