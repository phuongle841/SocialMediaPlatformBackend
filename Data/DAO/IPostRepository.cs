using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Data.DAO
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<List<Post>> GetAll();
        Task<Post> GetById(int id);
        Task<Post> Add(Post entity);
        Task<Post> Update(Post entity);
        Task<Post> Delete(Post entity);
    }
}
