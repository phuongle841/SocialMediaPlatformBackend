using SocialMediaPlatformBackend.Data.DAO;
using SocialMediaPlatformBackend.Data.DAO.Interfaces;
using SocialMediaPlatformBackend.Services.Implement;
using SocialMediaPlatformBackend.Services.Implements;
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
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<IReactionService, ReactionService>();
            services.AddScoped<IFriendService, FriendService>();
            services.AddScoped<IJwtService, JwtService>();

            return services;
        }
    }
}