using SocialMediaPlatformBackend.Data.DAO;
using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            // Add custom services here
            // services.AddScoped<IYourService, YourServiceImplementation>();
            services.AddScoped<IRepository<Profile>, ProfileRepository>();
            services.AddScoped<IRepository<Post>, PostRepository>();
            return services;
        }
    }
}