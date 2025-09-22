using Microsoft.EntityFrameworkCore;
using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Data.DAO
{
    public class ReactionRepository : IReactionRepository
    {
        private readonly AppDbContext _context;

        private readonly ILogger<ReactionRepository> _logger;
        public ReactionRepository(AppDbContext context, ILogger<ReactionRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Reaction> Add(Reaction entity)
        {
            await _context.Reactions.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Reaction> Delete(int Id)
        {
            var deletedReaction = await _context.Reactions.FindAsync(Id);
            if (deletedReaction == null)
            {
                return null;
            }
            _context.Reactions.Remove(deletedReaction);
            await _context.SaveChangesAsync();
            return deletedReaction;
        }

        public async Task<List<Reaction>> GetAll()
        {
            List<Reaction> reactions = await _context.Reactions.ToListAsync();
            return reactions;
        }

        public async Task<Reaction> GetById(int id)
        {
            try
            {
                Reaction reaction = await _context.Reactions.FindAsync(id);
                return reaction;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while retrieving the reaction with ID {ReactionId}", id);
                throw;
            }
        }

        public async Task<Reaction> Update(Reaction entity)
        {
            Reaction reaction = await _context.Reactions.FindAsync(entity.Id);
            if (reaction == null)
            {
                return null;
            }
            _context.Entry(reaction).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
