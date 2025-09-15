using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Data.DAO
{
    public interface IPostRepository : IRepository<Post>
    {
        new Task<List<Post>> GetAll();
        new Task<Post> GetById(int id);
        new Task<Post> Add(Post entity);
        new Task<Post> Update(Post entity);
        new Task<Post> Delete(Post entity);
    }
}
