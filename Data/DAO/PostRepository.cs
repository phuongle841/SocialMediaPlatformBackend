using Microsoft.EntityFrameworkCore;
using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Data.DAO
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<PostRepository> _logger;
        public PostRepository(AppDbContext dbContext, ILogger<PostRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Post> Add(Post entity)
        {
            var result = _dbContext.Posts.AddAsync(entity);
            _logger.LogInformation("Post added: {@Post}", result);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Post> Delete(Post entity)
        {
            var deletedPost = await _dbContext.Posts.FindAsync(entity.PostId);
            if (deletedPost == null)
            {
                return null;
            }
            _dbContext.Posts.Remove(deletedPost);
            await _dbContext.SaveChangesAsync();
            return entity;
        }


        public async Task<List<Post>> GetAll()
        {
            List<Post> posts = await _dbContext.Posts.ToListAsync();
            return posts;
        }

        public Task<Post> GetById(int id)
        {
            try
            {
                Post post = _dbContext.Posts.Find(id);
                return Task.FromResult(post);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while retrieving the post with ID {PostId}", id);
                throw;
            }
        }

        public async Task<Post> Update(Post entity)
        {
            Post existingPost = await _dbContext.Posts.FindAsync(entity.PostId);
            if (existingPost == null)
            {
                return null;
            }
            existingPost.Content = entity.Content;
            existingPost.ImageUrl = entity.ImageUrl;
            await _dbContext.SaveChangesAsync();
            return existingPost;
        }
    }
}
