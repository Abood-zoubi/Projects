using Biding_management_System.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Biding_management_System.Application.DTOs.Authentication;

namespace Biding_management_System.API.Controllers
{
    public class AuthenticationController : ControllerBase
    {
        [ApiController]
        [Route("api/authenticate")]
        public class AuthController : ControllerBase
        {
            private readonly AuthenticationService _authenticationService;

            public AuthController(AuthenticationService authenticationService)
            {
                _authenticationService = authenticationService;
            }

            [HttpPost("register")]
            public async Task<IActionResult> Register([FromBody] RegisterDTO request)
            {
                var result = await _authenticationService.RegisterUserAsync(request);
                return Ok(new { message = result });
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login([FromBody] LoginDTO request)
            {
                var token = await _authenticationService.LoginAsync(request);
                if (token == null) return Unauthorized(new { message = "Invalid credentials." });

                return Ok(new { token });
            }
        }

        public class RegisterRequest
        {
            public string Username { get; set; } = null!;
            public string Email { get; set; } = null!;
            public string Password { get; set; } = null!;
            public string Role { get; set; } = "Bidder";
        }

        public class LoginRequest
        {
            public string Email { get; set; } = null!;
            public string Password { get; set; } = null!;
        }
    }
}
