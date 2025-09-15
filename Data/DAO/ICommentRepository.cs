using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Data.DAO
{
    public interface ICommentRepository : IRepository<Comment>
    {
        new Task<List<Comment>> GetAll();
        new Task<Comment> GetById(int id);
        new Task<Comment> Add(Comment entity);
        new Task<Comment> Update(Comment entity);
        new Task<Comment> Delete(Comment entity);
    }
}
