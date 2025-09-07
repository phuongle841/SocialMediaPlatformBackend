namespace SocialMediaPlatformBackend.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int PostId { get; set; }
        public int UsertId { get; set; }
        public int ParenCommnedId { get; set; }
    }
}
