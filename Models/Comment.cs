namespace SocialMediaPlatformBackend.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public required int PostId { get; set; }
        public required int UserId { get; set; }
        // Nullable for top-level comments
        public int ParenCommentId { get; set; }
    }
}
