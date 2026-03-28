using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMediaPlatformBackend.Data.DTO.Request;
using SocialMediaPlatformBackend.Data.DTO.Response;
using SocialMediaPlatformBackend.Models;
using SocialMediaPlatformBackend.Services.Interfaces;

namespace SocialMediaPlatformBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FriendController : Controller
    {
        private readonly ILogger<FriendController> _logger;
        private readonly IFriendService _friendService;
        private readonly IMapper _mapper;
        public FriendController(IFriendService friendService, ILogger<FriendController> logger, IMapper mapper)
        {
            _friendService = friendService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{profileId:int}/friends")]
        public async Task<ActionResult> Get(int profileId)
        {
            IEnumerable<Friend> relationships = await _friendService.GetAllAsync(profileId);
            IEnumerable<RelationshipResDTO> relationshipRes = relationships.Select(_mapper.Map<RelationshipResDTO>);
            return Ok(relationshipRes);
        }

        [HttpGet("relationship")]
        public async Task<ActionResult> GetById([FromQuery] RelationshipReqDTO reqDTO)
        {
            Friend relationship = await _friendService.GetById(reqDTO.FollowerId, reqDTO.FollowingId);
            RelationshipResDTO relationshipRes = _mapper.Map<RelationshipResDTO>(relationship);
            if (relationshipRes == null)
            {
                return NotFound($"Friend relationship not found between {reqDTO.FollowerId} and {reqDTO.FollowingId}");
            }
            return Ok(relationshipRes);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RelationshipReqDTO reqDTO, FriendStatus status)
        {
            Friend? relationship = await _friendService.AddAsync(reqDTO.FollowerId, reqDTO.FollowingId, status);
            if (relationship == null)
            {
                return BadRequest("Unable to create friendship. One or both profiles may not exist.");
            }
            return Ok(_mapper.Map<RelationshipResDTO>(relationship));
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] RelationshipReqDTO reqDTO, FriendStatus status)
        {
            Friend relationship = await _friendService.UpdateAsync(reqDTO.FollowerId, reqDTO.FollowingId, status);
            if (relationship == null)
            {
                return NotFound("Relationship not found or cannot be updated.");
            }
            return Ok(_mapper.Map<RelationshipResDTO>(relationship));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] RelationshipReqDTO reqDTO)
        {
            Friend? relationship = await _friendService.DeleteAsync(reqDTO.FollowerId, reqDTO.FollowingId);
            if (relationship == null)
            {
                return NotFound($"Friendship not found between {reqDTO.FollowerId} and {reqDTO.FollowingId}");
            }
            return NoContent();
        }
    }
}
