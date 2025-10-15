using SocialMediaPlatformBackend.Data.DAO;
using SocialMediaPlatformBackend.Services;

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
            services.AddScoped<IReactionRepository, ReactionRepository>();

            services.AddScoped<IReactionService, ReactionService>();
            return services;
        }
    }
}