using Microsoft.AspNetCore.Mvc;
using SocialMediaPlatformBackend.Data.DAO;
using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        readonly ICommentRepository _commentRepository;
        readonly ILogger<CommentController> _logger;

        public CommentController(ICommentRepository commentRepository, ILogger<CommentController> logger)
        {
            _commentRepository = commentRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> Get()
        {
            var comments = await _commentRepository.GetAll();
            // Placeholder for getting comments
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var comment = await _commentRepository.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Comment comment)
        {
            var createdComment = await _commentRepository.Add(comment);
            return CreatedAtAction(nameof(Get), new { id = createdComment.Id }, createdComment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Comment comment)
        {
            var updatedComment = await _commentRepository.Update(comment);
            if (updatedComment == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _commentRepository.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }
            await _commentRepository.Delete(comment);
            return NoContent();
        }
    }
}
