using Microsoft.EntityFrameworkCore;
using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Data
{
    public static class SeedingExtension
    {
        public static void Seed(this DbContext context)
        {
            var profile = context.Set<Profile>().FirstOrDefault();
            if (profile == null)
            {
                profile = new Profile { Username = "string", LastName = "string", FirstName = "string", Email = "string@gmail.com" };
                context.Set<Profile>().Add(profile);
                context.SaveChanges();
            }

            var postExist = context.Set<Post>().Any();

            if (!postExist)
            {
                context.Set<Post>().Add(new Post { Profile = profile });
                context.SaveChanges();
            }
        }
        public static async Task SeedAsync(this DbContext context,CancellationToken cancellationToken)
        {
            Profile profile = await context.Set<Profile>().FirstOrDefaultAsync();
            if (profile == null)
            {
                profile = new Profile { Username = "string", LastName = "string", FirstName = "string", Email = "string@gmail.com" };
                await context.Set<Profile>().AddAsync(profile);
                await context.SaveChangesAsync();
            }

            var postExist = await context.Set<Post>().AnyAsync();

            if (!postExist)
            {
                await context.Set<Post>().AddAsync(new Post { Profile = profile });
                await context.SaveChangesAsync();
            }
        }
    }
}
