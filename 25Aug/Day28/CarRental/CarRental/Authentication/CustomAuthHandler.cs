using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using CarRental.Services;

namespace CarRental.Authentication
{
    public class CustomAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IJwtService _jwtService;

        public CustomAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger, UrlEncoder encoder, IJwtService jwtService)
            : base(options, logger, encoder)
        {
            _jwtService = jwtService;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // Check for X-JWT-Token header
            if (!Request.Headers.ContainsKey("X-JWT-Token"))
            {
                return Task.FromResult(AuthenticateResult.Fail("Missing X-JWT-Token header"));
            }

            var token = Request.Headers["X-JWT-Token"].ToString();

            if (string.IsNullOrEmpty(token))
            {
                return Task.FromResult(AuthenticateResult.Fail("Empty token"));
            }

            // Validate token
            if (!_jwtService.ValidateToken(token))
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid token"));
            }

            // Create claims and return success
            var claims = new[] { new Claim(ClaimTypes.Name, "admin") };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}