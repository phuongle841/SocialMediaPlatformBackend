using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMediaPlatformBackend.Models;
using System.Reflection.Metadata;

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
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SocialMediaPlatformDb;Trusted_Connection=True;")
                .UseAsyncSeeding(async (context, _, CancellationToken) =>
                {
                    var profile = await context.Set<Profile>().FirstOrDefaultAsync();
                    if (profile == null)
                    {
                        context.Set<Profile>().Add(
                            new Profile
                            {
                                ProfileId = 1,
                                Username = "john_doe",
                                FirstName = "John",
                                LastName = "Doe",
                                DateOfBirth = new DateTime(2026, 3, 26, 0, 0, 0, DateTimeKind.Utc),
                                CreatedAt = new DateTime(2026, 3, 26, 0, 0, 0, DateTimeKind.Utc),
                                UpdatedAt = new DateTime(2026, 3, 26, 0, 0, 0, DateTimeKind.Utc),
                                Email = "John_do3@gmail.com",
                                Bio = "Just a regular guy who loves coding and coffee."
                            }
                        );
                        await context.SaveChangesAsync();
                    }
                });
        }

        public static void AddAsyncSeeding(this DbContextOptionsBuilder builder, IServiceProvider serviceProvider)
        {
            builder.UseAsyncSeeding(async (context, _, ct) =>
            {
                var initialiser = serviceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
                await initialiser.SeedAsync();
            });

            builder.UseSeeding((context, _) =>
            {
                var initialiser = serviceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
                // Block on async call for sync context
                initialiser.SeedAsync().GetAwaiter().GetResult();
            });
        }
    }
}