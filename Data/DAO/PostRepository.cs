using Microsoft.EntityFrameworkCore;
using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Data.DAO
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _dbContext;
        public PostRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddPost(Post entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePost(Post entity)
        {
            throw new NotImplementedException();
        }


        public async Task<List<Post>> getAllPosts()
        {
            List<Post> posts = await _dbContext.Posts.ToListAsync();
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
            _dbContext.SaveChanges();
            return posts;
        }

        public async Task<Post> getPostById(int id)
        {
            Post? post = await _dbContext.Posts.FindAsync(id);
            return post;
        }

        public async Task UpdatePost(Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
