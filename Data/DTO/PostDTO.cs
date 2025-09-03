namespace SocialMediaPlatformBackend.Data.DTO
{
    public class PostDTO
    {
        public int Post_id { get; set; }
        public string content { get; set; }
        public string image_url { get; set; }
        public DateTime created_at { get; set; }
        public int likes_count { get; set; }
        public int comments_count { get; set; }
    }
}
