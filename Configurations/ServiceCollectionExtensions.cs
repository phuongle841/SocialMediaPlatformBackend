using SocialMediaPlatformBackend.Data.DAO;
using SocialMediaPlatformBackend.Services.Implement;
using SocialMediaPlatformBackend.Services.Interfaces;

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
            services.AddScoped<IFriendRepository, FriendRepository>();

            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IReactionService, ReactionService>();
            services.AddScoped<IFriendService, FriendService>();
            services.AddScoped<IJwtService, JwtService>();

            return services;
        }
    }
}