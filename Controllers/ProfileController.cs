using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaPlatformBackend.Data.DAO.Interfaces;
using SocialMediaPlatformBackend.Data.DTO;
using SocialMediaPlatformBackend.Services.Interfaces;
using System.Security.Claims;

namespace SocialMediaPlatformBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly IProfileService _profileService;
        private readonly IMapper _mapper;
        public ProfileController(ILogger<ProfileController> logger, IMapper mapper, IProfileService profileService)
        {
            _logger = logger;
            _mapper = mapper;
            _profileService = profileService;
        }


        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Profile>>> Get()
        {

            var profiles = await _profileService.GetAllAsync();
            var dtoProfiles = _mapper.Map<IEnumerable<ProfileDTO>>(profiles);

            return Ok(dtoProfiles);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var identity = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "uid", null);
            _logger.LogInformation(identity?.Value);

            var profile = await _profileService.GetByIdAsync(id);
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
            var createdProfile = await _profileService.AddAsync(profile);

            return CreatedAtAction(nameof(Get), new { id = createdProfile.ProfileId }, createdProfile);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProfileDTO profileDTO)
        {
            Models.Profile profile = _mapper.Map<Models.Profile>(profileDTO);
            var updatedProfile = await _profileService.UpdateAsync(id, profile);
            if (updatedProfile == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var profile = await _profileService.GetByIdAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            await _profileService.DeleteAsync(id);
            return NoContent();
        }
    }
}
