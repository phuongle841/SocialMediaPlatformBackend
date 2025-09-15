using Microsoft.EntityFrameworkCore;
using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Data.DAO
{

    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CommentRepository> _logger;
        public CommentRepository(AppDbContext context, ILogger<CommentRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Comment> Add(Comment entity)
        {
            await _context.Comments.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Comment> Delete(Comment entity)
        {
            var deletedComment = await _context.Comments.FindAsync(entity.Id);
            if (deletedComment == null)
            {
                return null;
            }
            _context.Comments.Remove(deletedComment);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Comment>> GetAll()
        {
            List<Comment> comments = await _context.Comments.ToListAsync();
            return comments;
        }

        public async Task<Comment> GetById(int id)
        {
            try
            {
                Comment comment = await _context.Comments.FindAsync(id);
                return comment;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while retrieving the comment with ID {CommentId}", id);
                throw;
            }
        }

        public async Task<Comment> Update(Comment entity)
        {
            Comment existingComment = await _context.Comments.FindAsync(entity.Id);
            if (existingComment == null)
            {
                return null;
            }
            _context.Entry(existingComment).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
