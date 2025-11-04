using Microsoft.AspNetCore.Mvc;
using SocialMediaPlatformBackend.Services;

namespace SocialMediaPlatformBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FriendController : Controller
    {
        private readonly ILogger<FriendController> _logger;
        private readonly IFriendService _friendService;

        public FriendController(IFriendService friendService, ILogger<FriendController> logger)
        {
            _friendService = friendService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {

            return NotFound();
        }


    }
}
