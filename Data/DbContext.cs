using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Data
{
    public class AppDbContext : IdentityDbContext<User, Role, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Friend> Relations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Friend> Friends { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // 03/11/2025: TODO: relationship configurations of friends and profiles
            modelBuilder.Entity<Friend>()
                .HasOne(f => f.Follower)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Friend>()
                .HasOne(f => f.Following)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            // Configure the Profile entity
            // Seeding data
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }
}
