using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Services.Interfaces
{
    public interface IReactionService
    {
        public Task<List<Reaction>> GetAllAsync();
        public Task<Reaction> GetByIdAsync(int id);
        public Task AddAsync(Reaction reaction);
        public Task UpdateAsync(Reaction reaction);
        public Task DeleteAsync(int id);
    }

}
