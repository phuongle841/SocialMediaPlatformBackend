using Microsoft.EntityFrameworkCore;
using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the Profile entity


            // Seeding data
            modelBuilder.Entity<Profile>().HasData(
                new Profile
                {
                    ProfileId = 1,
                    Username = "john_doe",
                    Email = "John@google.com",
                    PasswordHash = "hashed_password_123",
                    FirstName = "John",
                    LastName = "Doe",
                    ProfilePicture = "https://pbs.twimg.com/profile_images/1938321133884813312/BU8hdbr__400x400.jpg",
                    Bio = "Just a regular John Doe.",
                    DateOfBirth = new DateTime(1990, 1, 1),
                }
            );

            var fixedTime = new DateTime(2025, 8, 29, 10, 0, 0);
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    PostId = 1,
                    Content = "Hello, world! This is my first post.",
                    ImageUrl = "https://example.com/posts/first_post.jpg",
                    CreatedAt = fixedTime,
                    UpdatedAt = fixedTime,
                    LikesCount = 0,
                    CommentsCount = 0,
                    IsActive = true,
                    //ProfileId = 1 // Foreign key to the seeded profile
                }
            );

        }

    }
}
