using Microsoft.AspNetCore.Mvc;
using SocialMediaPlatformBackend.Data.DAO;
using SocialMediaPlatformBackend.Data.DTO;
using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly IRepository<Post> _postRepository;
        public PostController(IRepository<Post> postRepository, ILogger<PostController> logger)
        {
            _postRepository = postRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? order)
        {
            IEnumerable<Post> repoPost = await _postRepository.GetAll();
            if (order?.ToLower() == "asc")
            {
                repoPost = repoPost.OrderBy(p => p.CreatedAt);
            }

            IEnumerable<PostDTO> dtoPosts = from b in repoPost
                                            select new PostDTO()
                                            {
                                                PostId = b.PostId,
                                                Content = b.Content,
                                                ImageUrl = b.ImageUrl,
                                                CreatedAt = b.CreatedAt,
                                                LikesCount = b.LikesCount,
                                                CommentsCount = b.CommentsCount,
                                            };
            return Ok(dtoPosts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Post? post = await _postRepository.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            PostDTO postDTO = new PostDTO()
            {
                PostId = post.PostId,
                Content = post.Content,
                ImageUrl = post.ImageUrl,
                CreatedAt = post.CreatedAt,
                LikesCount = post.LikesCount,
                CommentsCount = post.CommentsCount,
            };

            return Ok(postDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostDTO postDTO)
        {
            Post post = new Post
            {
                Content = postDTO.Content,
                ImageUrl = postDTO.ImageUrl,
                CreatedAt = DateTime.Now,
                LikesCount = 0,
                CommentsCount = 0,
                IsActive = true
            };
            await _postRepository.Add(post);

            return CreatedAtAction(nameof(Get), new { id = post.PostId }, postDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PostDTO postDTO)
        {
            Post post = new Post
            {
                PostId = id,
                Content = postDTO.Content,
                ImageUrl = postDTO.ImageUrl,
            };
            await _postRepository.Update(post);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            Post post = await _postRepository.GetById(id);
            if (post == null) return NotFound();

            await _postRepository.Delete(post);
            return Ok();
        }
    }
}
