using Microsoft.EntityFrameworkCore;

namespace EmployMain.Models
{
    public class EmployDbContext : DbContext
    {
        public EmployDbContext(DbContextOptions<EmployDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employ>().ToTable("Employ");
        }

        public DbSet<Employ> Employees { get; set; }
    }
}
