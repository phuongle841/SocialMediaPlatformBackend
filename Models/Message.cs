namespace SocialMediaPlatformBackend.Models
{
    public class Message
    {
        public int Id { get; set; }
        public required int SenderId { get; set; }
        public required int ReceiverId { get; set; }
        public required string Content { get; set; }

    }
}
