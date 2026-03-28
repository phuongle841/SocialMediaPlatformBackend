using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMediaPlatformBackend.Data.DAO.Interfaces;
using SocialMediaPlatformBackend.Data.DTO;
using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public PostController(IPostRepository postRepository, ILogger<PostController> logger, IMapper mapper)
        {
            _postRepository = postRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? order, CancellationToken cancellationToken)
        {
            IEnumerable<Post> posts;

            var claims = HttpContext.User.Claims.Select(c => new { c.Type, c.Value }).ToList();
            claims.ForEach(e => _logger.LogInformation(e.Type + " :" + e.Value));

            try
            {
                posts = await _postRepository.GetAll();
            }
            catch (Exception)
            {
                _logger.LogError("An error occurred while retrieving posts.");
                throw;
            }
            if (order?.ToLower() == "asc")
            {
                posts = posts.OrderBy(p => p.CreatedAt);
            }
            
            var postDTO = _mapper.Map<IEnumerable<PostDTO>>(posts);
            return Ok(postDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Post? post = await _postRepository.GetById(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PostDTO>(post));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostDTO postDTO)
        {
            _logger.LogInformation("Creating a new post with content: {Content}", postDTO);
            Post post = new Post
            {
                Content = postDTO.Content,
                ImageUrl = postDTO.ImageUrl,
                CreatedAt = DateTime.Now,
                LikesCount = 0,
                CommentsCount = 0,
                IsActive = true,
                ProfileId = postDTO.ProfileId,
            };
            Post addedPost = await _postRepository.Add(post);
            return CreatedAtAction(nameof(Get), new { id = addedPost.PostId }, postDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PostDTO postDTO)
        {
            Post post = new Post
            {
                PostId = id,
                Content = postDTO.Content,
                ImageUrl = postDTO.ImageUrl,
                ProfileId = postDTO.ProfileId,
                Profile = null!
            };
            var existingPost = await _postRepository.GetById(id);
            if (existingPost==null)
            {
                return NotFound();
            }
            await _postRepository.Update(post);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            Post post = await _postRepository.GetById(id);
            if (post == null) return NotFound();

            await _postRepository.Delete(post);
            return NoContent();
        }
    }
}
