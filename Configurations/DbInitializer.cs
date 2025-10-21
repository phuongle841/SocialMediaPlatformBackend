using Microsoft.AspNetCore.Identity;
using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Configurations
{
    public class DbInitializer
    {
        public static async Task SeedRoleAsync(RoleManager<Role> roleManager)
        {
            var roles = new[] { "User", "Admin" };
            foreach (var roleName in roles)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new Role { Name = roleName });
                }
            }
        }
    }
}
