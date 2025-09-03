namespace SocialMediaPlatformBackend.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
        public bool IsActive { get; set; }
        // Foreign key to Profile
        public int? ProfileId { get; set; }
        public Profile? Profile { get; set; }
    }
}
