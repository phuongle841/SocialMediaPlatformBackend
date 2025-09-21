using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMediaPlatformBackend.Data.DAO;
using SocialMediaPlatformBackend.Data.DTO;

namespace SocialMediaPlatformBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;
        public ProfileController(ILogger<ProfileController> logger, IProfileRepository profileRepository, IMapper mapper)
        {
            _logger = logger;
            _profileRepository = profileRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Profile>>> Get()
        {
            var profiles = await _profileRepository.GetAll();
            var dtoProfiles = _mapper.Map<IEnumerable<ProfileDTO>>(profiles);

            return Ok(dtoProfiles);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var profile = await _profileRepository.GetById(id);
            if (profile == null)
            {
                return NotFound();
            }
            ProfileDTO profileDTO = _mapper.Map<ProfileDTO>(profile);
            return Ok(profileDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProfileDTO profileDTO)
        {
            Models.Profile profile = _mapper.Map<Models.Profile>(profileDTO);
            var createdProfile = await _profileRepository.Add(profile);

            return CreatedAtAction(nameof(Get), new { id = createdProfile.ProfileId }, createdProfile);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProfileDTO profileDTO)
        {
            Models.Profile profile = _mapper.Map<Models.Profile>(profileDTO);
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
