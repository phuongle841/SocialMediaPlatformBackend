namespace SocialMediaPlatformBackend.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public NotificationTypes NotificationTypes { get; set; }
        public int EntityId { get; set; }
        public bool isRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public enum NotificationTypes
    {
        Like,
        Comment,
        Follow,
        Mention,
    }
}
