using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using CarRental.Services;
using CarRental.DTOs;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public AuthController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public ActionResult<LoginResponseDto> Login([FromBody] LoginDto loginDto)
        {
            // Simple hardcoded validation (in real app, check database)
            if (loginDto.Username == "admin" && loginDto.Password == "password123")
            {
                var token = _jwtService.GenerateToken(loginDto.Username);
                return Ok(new LoginResponseDto
                {
                    Token = token,
                    Message = "Login successful"
                });
            }

            return Unauthorized(new LoginResponseDto
            {
                Message = "Invalid username or password"
            });
        }

        [HttpGet("github")]
        public IActionResult GitHubLogin()
        {
            var redirectUrl = Url.Action("GitHubCallback", "Auth");
            var properties = new Microsoft.AspNetCore.Authentication.AuthenticationProperties
            {
                RedirectUri = redirectUrl
            };
            return Challenge(properties, "GitHub");
        }

        [HttpGet("github-callback")]
        public async Task<IActionResult> GitHubCallback()
        {
            var result = await HttpContext.AuthenticateAsync("GitHub");
            if (result.Succeeded)
            {
                // Redirect back to React app with success parameter
                return Redirect("http://localhost:3000?github=success");
            }
            return Redirect("http://localhost:3000?github=failed");
        }


    }
}