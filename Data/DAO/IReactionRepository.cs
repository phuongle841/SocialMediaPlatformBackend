using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Data.DAO
{
    public interface IReactionRepository
    {
        Task<List<Reaction>> GetAll();
        Task<Reaction> GetById(int id);
        Task<Reaction> Add(Reaction entity);
        Task<Reaction> Update(Reaction entity);
        Task<Reaction> Delete(int Id);
    }
}
