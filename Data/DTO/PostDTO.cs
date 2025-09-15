namespace SocialMediaPlatformBackend.Data.DTO
{
    public class PostDTO
    {
        public int PostId { get; set; }
        public required string Content { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
    }
}
