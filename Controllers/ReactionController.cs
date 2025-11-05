using Microsoft.AspNetCore.Mvc;
using SocialMediaPlatformBackend.Models;
using SocialMediaPlatformBackend.Services.Interfaces;

namespace SocialMediaPlatformBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReactionController : Controller
    {
        private readonly ILogger<ReactionController> _logger;
        private readonly IReactionService _reactionService;

        public ReactionController(IReactionService reactionService, ILogger<ReactionController> logger)
        {
            _reactionService = reactionService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reaction>>> Get()
        {
            IEnumerable<Reaction> reactions = await _reactionService.GetAllAsync();
            return Ok(reactions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get(int id)
        {
            Reaction reaction = await _reactionService.GetByIdAsync(id);
            if (reaction == null)
            {
                return NotFound();
            }
            return Ok(reaction);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reaction reaction)
        {
            await _reactionService.AddAsync(reaction);
            return CreatedAtAction(nameof(Get), new { id = reaction.Id }, reaction);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Reaction reaction)
        {
            await _reactionService.UpdateAsync(reaction);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _reactionService.DeleteAsync(id);
            return NoContent();
        }

    }
}
