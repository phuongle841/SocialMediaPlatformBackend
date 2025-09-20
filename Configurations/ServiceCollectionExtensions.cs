using SocialMediaPlatformBackend.Data.DAO;

namespace SocialMediaPlatformBackend.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            // Add custom services here
            // services.AddScoped<IYourService, YourServiceImplementation>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            return services;
        }
    }
}