namespace SocialMediaPlatformBackend.Models
{
    public class Post
    {
        public int Post_id { get; set; }
        public string content { get; set; }
        public string image_url { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int likes_count { get; set; }
        public int comments_count { get; set; }
        public bool is_active { get; set; }
        // Foreign key to Profile
        public int user_id { get; set; }
        public Profile Profile { get; set; }
    }
}
