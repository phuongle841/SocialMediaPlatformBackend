using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaPlatformBackend.Data;
using SocialMediaPlatformBackend.Data.DAO;
using SocialMediaPlatformBackend.Data.DTO;
using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PostController> _logger;
        private readonly IPostRepository _postRepository;
        public PostController(AppDbContext context, IPostRepository postRepository, ILogger<PostController> logger)
        {
            _context = context;
            _postRepository = postRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? Order)
        {
            IEnumerable<Post> repoPost = await _postRepository.getAllPosts();

            IEnumerable<PostDTO> dtoPosts = from b in repoPost
                                            select new PostDTO()
                                            {
                                                Post_id = b.PostId,
                                                content = b.Content,
                                                image_url = b.ImageUrl,
                                                created_at = b.CreatedAt,
                                                likes_count = b.LikesCount,
                                                comments_count = b.CommentsCount,
                                            };
            return Ok(dtoPosts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Post? post = await _postRepository.getPostById(id);
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Post post)
        {

            _logger.LogInformation("Received Post: {@Post}", post);
            Post newPost = new Post
            {
                //Test if Id is auto- incremented
                //PostId = 1,
                Content = "Hello, world! This is my Second post.",
                ImageUrl = "https://example.com/posts/first_post.jpg",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                LikesCount = 0,
                CommentsCount = 0,
                IsActive = true,
                //Test ProfileId is required
                ProfileId = 1
            };
            await _context.Posts.AddAsync(newPost);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            // Here you would typically update the post in the database
            await _context.Posts.Where(p => p.PostId == id).ForEachAsync(p => p.Content = value);
            await _context.SaveChangesAsync();
            return Ok(await _context.Posts.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            // Here you would typically delete the post from the database
            _context.Posts.Remove(new Models.Post { PostId = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
