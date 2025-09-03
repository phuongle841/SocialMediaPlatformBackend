using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Data.DAO
{
    public interface IPostRepository
    {
        Task<List<Post>> getAllPosts();
        Task<Post> getPostById(int id);
        Task AddPost(Post entity);
        Task UpdatePost(Post entity);
        Task DeletePost(Post entity);
    }
}
