namespace SocialMediaPlatformBackend.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
