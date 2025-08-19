using Microsoft.EntityFrameworkCore;

namespace EmployCrud.Models
{
    public class EFCoreDbContext : DbContext
    {
        public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employ2>().ToTable("Employ1");
        }

        public DbSet<Employ2> Employ { get; set; }
    }
}
