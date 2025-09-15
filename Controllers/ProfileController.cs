using Microsoft.AspNetCore.Mvc;
using SocialMediaPlatformBackend.Data;
using SocialMediaPlatformBackend.Data.DAO;

namespace SocialMediaPlatformBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfileController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ProfileController> _logger;
        private readonly IProfileRepository _profileRepository;
        public ProfileController(AppDbContext context, ILogger<ProfileController> logger, IProfileRepository profileRepository)
        {
            _context = context;
            _logger = logger;
            _profileRepository = profileRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profile>>> Get()
        {
            var profiles = await _profileRepository.GetAll();

            return Ok(profiles);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var profile = await _profileRepository.GetById(id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Profile profile)
        {
            var createdProfile = await _profileRepository.Add(profile);
            return CreatedAtAction(nameof(Get), new { id = createdProfile.ProfileId }, createdProfile);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Profile profile)
        {
            var updatedProfile = await _profileRepository.Update(profile);
            if (updatedProfile == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var profile = await _profileRepository.GetById(id);
            if (profile == null)
            {
                return NotFound();
            }
            await _profileRepository.Delete(profile);
            return NoContent();
        }
    }
}
