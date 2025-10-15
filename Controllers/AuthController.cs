using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialMediaPlatformBackend.Data.DTO;
using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(ILogger<AuthController> logger, UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        // Implement registration, login, and other authentication-related actions here
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO user)
        {
            User newUser = new User()
            {
                UserName = user.UserName,
                Email = user.Email
            };


            var result = await _userManager.CreateAsync(newUser, user.Password);
            if (result.Succeeded)
            {
                return Ok("User registered successfully");
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, false);

            _logger.LogInformation(result.IsLockedOut.ToString());

            if (result.Succeeded)
            {
                return Ok("User logged in successfully");
            }

            return Unauthorized();
        }
    }
}
