using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMediaPlatformBackend.Data.DTO.Request;
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

        [HttpGet("{profileId}")]
        public async Task<ActionResult> Get(int profileId)
        {
            IEnumerable<Friend> relationships = await _friendService.GetAllAsync(profileId);
            return Ok(relationships);
        }

        [HttpGet]
        public async Task<ActionResult> GetById([FromBody] RelationshipReqDTO reqDTO)
        {
            Friend relationship = await _friendService.GetById(reqDTO.FollowerId, reqDTO.FollowingId);
            return Ok(relationship);
        }


    }
}
