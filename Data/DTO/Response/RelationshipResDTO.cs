using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Data.DTO.Response
{
    public class RelationshipResDTO
    {
        public ProfileDTO Follower { set; get; }
        public ProfileDTO Following { set; get; }
        public DateTime CreateAt { set; get; }
        public FriendStatus Status { set; get; }
    }
}
