using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialMediaPlatformBackend.Data.DTO;
using SocialMediaPlatformBackend.Models;
using SocialMediaPlatformBackend.Services.Interfaces;

namespace SocialMediaPlatformBackend.Controllers
{
    public class AuthController : ControllerBase
    {

        // how to generate and validate JWTs for this configuration (e.g., login endpoint + token creation)


        private readonly ILogger<AuthController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtService _jwtService;

        public AuthController(ILogger<AuthController> logger, UserManager<User> userManager, SignInManager<User> signInManager, IJwtService jwtService)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
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
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            await _userManager.AddToRoleAsync(newUser, "User");

            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return Unauthorized("Invalid UserName");
            }

            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
            if (!result.Succeeded)
            {
                return Unauthorized("Invalid Password");
            }

            _logger.LogInformation("Success log in");

            var token = await _jwtService.GenerateToken(user);

            return Ok(new { token });

        }
    }
}
