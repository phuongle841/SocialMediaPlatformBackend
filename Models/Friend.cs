namespace SocialMediaPlatformBackend.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public int FollowerId { get; set; }
        public string FollowingId { get; set; }
        public DateTime CreateAt { get; set; }
        public FriendStatus Status { get; set; }
    }
    public enum FriendStatus
    {
        Pending,
        Accepted,
        Blocked
    }
}
