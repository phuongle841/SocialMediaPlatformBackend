namespace SocialMediaPlatformBackend.Models
{
    public class Reaction
    {
        public int Id { get; set; }
        public required int ProfileId { get; set; }
        public int? CommentId { get; set; }
        public int? PostId { get; set; }
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
