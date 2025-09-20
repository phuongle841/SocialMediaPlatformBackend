namespace SocialMediaPlatformBackend.Models
{
    public class Post
    {
        public int PostId { get; set; }
        // Content or ImageUrl, one must be provided
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int LikesCount { get; set; } = 0;
        public int CommentsCount { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        // Foreign key to Profile
        public int? ProfileId { get; set; }
        public Profile? Profile { get; set; }
    }
}
