using JwtExampleDotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTExampledotnet.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
