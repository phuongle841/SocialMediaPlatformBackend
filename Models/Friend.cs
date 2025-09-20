namespace SocialMediaPlatformBackend.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public required int FollowerId { get; set; }
        public required string FollowingId { get; set; }
        public DateTime CreateAt { get; set; }
        public FriendStatus Status { get; set; } = FriendStatus.Pending;
    }
    public enum FriendStatus
    {
        Pending,
        Accepted,
        Blocked
    }
}
