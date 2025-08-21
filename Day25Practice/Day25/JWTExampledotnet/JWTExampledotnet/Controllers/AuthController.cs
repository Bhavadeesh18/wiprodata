using JWTExampledotnet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using LoginRequest = JwtExampleDotnet.Models.LoginRequest;


namespace JwtExampleDotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthservice _authService;

        public AuthController(IAuthservice authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.Authenticate(request.Username, request.Password);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Invalid credentials");
            }
            return Ok(new { Token = token });
        }
    }
}