using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMediaPlatformBackend.Data;
using SocialMediaPlatformBackend.Data.DTO;
using SocialMediaPlatformBackend.Models;
using System.Text.Json;

namespace SocialMediaPlatformBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<PostController> _logger;
        public PostController(AppDbContext context, IMapper mapper, ILogger<PostController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            string response = JsonSerializer.Serialize("Hello from PostController");
            Post post = new Post
            {
                Post_id = 1,
                content = "This is a sample post",
                image_url = "http://example.com/image.jpg",
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
                likes_count = 10,
                comments_count = 5,
                is_active = true,
                user_id = 1
            };
            var postDTO = _mapper.Map<PostDTO>(post);
            _logger.LogInformation("Mapped Post to PostDTO: {@PostDTO}", postDTO);
            return response;
        }
        [HttpGet("{id}")]
        public String Get(int id)
        {
            string response = JsonSerializer.Serialize($"Hello from PostController with id: {id}");
            return response;
        }

        [HttpPost]
        public string Post([FromBody] string value)
        {
            string response = JsonSerializer.Serialize(value);
            return "Ok";
        }

        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string value)
        {
            // Here you would typically update the post in the database
            Console.WriteLine($"Post with ID {id} updated to: {value}");
            return "Ok";
        }
    }
}
