using CarRental.Data;
using CarRental.Services;
using CarRental.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.OAuth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("JWT", new OpenApiSecurityScheme
    {
        Description = "JWT token directly. Example: \"X-JWT-Token: {token}\"",
        Name = "X-JWT-Token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "JWT"
                }
            },
            new string[] {}
        }
    });
});

// Add DbContext
builder.Services.AddDbContext<CarRentalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add Services
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IJwtService, JwtService>();

// Add Multiple Authentication Schemes
builder.Services.AddAuthentication("Custom")
    .AddScheme<Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions, CustomAuthHandler>("Custom", options => { })
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/api/auth/github"; // Redirect to GitHub OAuth instead of Account/Login
        options.AccessDeniedPath = "/api/auth/github";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromHours(1);
    })
    .AddOAuth("GitHub", options =>
    {
        options.ClientId = builder.Configuration["GitHub:ClientId"];
        options.ClientSecret = builder.Configuration["GitHub:ClientSecret"];
        options.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
        options.TokenEndpoint = "https://github.com/login/oauth/access_token";
        options.UserInformationEndpoint = "https://api.github.com/user";
        options.CallbackPath = "/api/auth/github-callback";
        options.Scope.Add("user:email");
        options.SignInScheme = "Cookies";
        
        options.Events = new OAuthEvents
        {
            OnCreatingTicket = async context =>
            {
                var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", context.AccessToken);

                var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
                response.EnsureSuccessStatusCode();

                var json = System.Text.Json.JsonDocument.Parse(await response.Content.ReadAsStringAsync());
                
                // Add claims manually
                if (json.RootElement.TryGetProperty("id", out var id))
                {
                    context.Identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, id.ToString() ?? "unknown"));
                }
                if (json.RootElement.TryGetProperty("login", out var login) && !string.IsNullOrEmpty(login.GetString()))
                {
                    context.Identity.AddClaim(new Claim(ClaimTypes.Name, login.GetString()));
                }
                if (json.RootElement.TryGetProperty("email", out var email) && !string.IsNullOrEmpty(email.GetString()))
                {
                    context.Identity.AddClaim(new Claim(ClaimTypes.Email, email.GetString()));
                }
                else
                {
                    context.Identity.AddClaim(new Claim(ClaimTypes.Email, "noemail@github.com"));
                }
            }
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
