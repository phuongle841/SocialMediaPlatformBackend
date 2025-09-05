using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(
                new Post
                {
                    PostId = 1,
                    Content = "Hello, world! This is my first post.",
                    ImageUrl = "https://example.com/posts/first_post.jpg",
                    CreatedAt = new DateTime(2025, 8, 29, 10, 0, 0),
                    UpdatedAt = new DateTime(2025, 8, 29, 10, 0, 0),
                    LikesCount = 0,
                    CommentsCount = 0,
                    IsActive = true,
                    ProfileId = 1
                },
                new Post
                {
                    PostId = 2,
                    Content = "Just had a great day at the park!",
                    ImageUrl = "https://example.com/posts/park_day.jpg",
                    CreatedAt = new DateTime(2025, 8, 30, 15, 30, 0),
                    UpdatedAt = new DateTime(2025, 8, 30, 15, 30, 0),
                    LikesCount = 5,
                    CommentsCount = 2,
                    IsActive = true,
                    ProfileId = 2
                }
            );
        }
    }
}
