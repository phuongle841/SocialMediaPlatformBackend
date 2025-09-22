using SocialMediaPlatformBackend.Data.DAO;
using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Services
{

    public class ReactionService : IReactionService
    {
        private readonly ILogger<ReactionService> _logger;
        private readonly IReactionRepository _reactionRepository;

        public ReactionService(IReactionRepository reactionRepository, ILogger<ReactionService> logger)
        {
            _reactionRepository = reactionRepository;
            _logger = logger;
        }

        public async Task AddAsync(Reaction reaction)
        {
            await _reactionRepository.Add(reaction);
        }

        public async Task DeleteAsync(int Id)
        {
            await _reactionRepository.Delete(Id);
        }

        public async Task<List<Reaction>> GetAllAsync()
        {
            List<Reaction> reactions = await _reactionRepository.GetAll();
            return reactions;
        }

        public async Task<Reaction> GetByIdAsync(int id)
        {
            Reaction reaction = await _reactionRepository.GetById(id);
            return reaction;
        }
        // Should return the result of the update operation
        public async Task UpdateAsync(Reaction reaction)
        {
            await _reactionRepository.Update(reaction);
        }
    }
}
