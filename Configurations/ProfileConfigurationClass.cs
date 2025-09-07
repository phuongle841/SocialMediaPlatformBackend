using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SocialMediaPlatformBackend.Configurations
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasData(new Profile
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
            },
                new Profile
                {
                    ProfileId = 2,
                    Username = "Cyb3rAngel",
                    Email = "John@google.com",
                    PasswordHash = "hashed_password_123",
                    FirstName = "John",
                    LastName = "Doe",
                    ProfilePicture = "https://pbs.twimg.com/profile_images/1938321133884813312/BU8hdbr__400x400.jpg",
                    Bio = "Just a regular John Doe.",
                    DateOfBirth = new DateTime(1990, 1, 1),
                }
             );
        }
    }
}
