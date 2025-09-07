namespace SocialMediaPlatformBackend.Models
{
    public class Reaction
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? CommentId { get; set; }
        public DateTime CreateAt { get; set; }
    }
    public enum ReactionTypes
    {
        Like,
        Love,
        Haha,
        Sad,
    }
}
