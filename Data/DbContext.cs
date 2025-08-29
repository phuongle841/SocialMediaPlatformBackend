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
            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(e => e.user_id);
                entity.Property(e => e.username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.password_hash).IsRequired();
                entity.Property(e => e.first_name).HasMaxLength(50);
                entity.Property(e => e.last_name).HasMaxLength(50);
                entity.Property(e => e.profile_picture).HasMaxLength(255);
                entity.Property(e => e.bio).HasMaxLength(500);
                entity.Property(e => e.created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.updated_at).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.is_active).HasDefaultValue(true);
                entity.Property(e => e.last_login).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
            // Configure the Post entity
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.Post_id);
                entity.Property(e => e.content).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.image_url).HasMaxLength(255);
                entity.Property(e => e.created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.updated_at).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.likes_count).HasDefaultValue(0);
                entity.Property(e => e.comments_count).HasDefaultValue(0);
                entity.Property(e => e.is_active).HasDefaultValue(true);
                // Configure the foreign key relationship with Profile
                entity.HasOne(d => d.Profile)
                      .WithMany()
                      .HasForeignKey(d => d.user_id)
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();
            });

            // Seed initial data if necessary
            var initialProfile = new Profile
            {
                user_id = 1,
                username = "admin",
                email = "",
            };
            modelBuilder.Entity<Profile>().HasData(initialProfile);

            var initialPost = new Post
            {
                Post_id = 1,
                content = "Welcome to the Social Media Platform!",
                user_id = initialProfile.user_id
            };
            modelBuilder.Entity<Post>().HasData(initialPost);
        }
    }
}
