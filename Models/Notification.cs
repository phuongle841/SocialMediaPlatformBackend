namespace SocialMediaPlatformBackend.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public required NotificationTypes NotificationTypes { get; set; }
        public required int EntityId { get; set; }
        public required bool isRead { get; set; }
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
