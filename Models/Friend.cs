namespace SocialMediaPlatformBackend.Models
{
    // Relationship
    public class Friend
    {
        public int Id { get; set; }
        public required Profile Follower { get; set; }
        public required Profile Following { get; set; }
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
