using CarRental.Services;
using System.Security.Claims;

namespace CarRental.Middleware
{
    public class CustomJwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IJwtService _jwtService;

        public CustomJwtMiddleware(RequestDelegate next, IJwtService jwtService)
        {
            _next = next;
            _jwtService = jwtService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["X-JWT-Token"].FirstOrDefault();

            if (!string.IsNullOrEmpty(token))
            {
                if (_jwtService.ValidateToken(token))
                {
                    // Set user as authenticated
                    var claims = new[] { new Claim(ClaimTypes.Name, "admin") };
                    var identity = new ClaimsIdentity(claims, "custom");
                    context.User = new ClaimsPrincipal(identity);
                }
            }

            await _next(context);
        }
    }
}