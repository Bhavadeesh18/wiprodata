using Microsoft.EntityFrameworkCore;

namespace RestEmployCrud.Models
{
    public class EmployDBContext : DbContext
    {
        //Constructor calling the Base DbContext Class Constructor
        public EmployDBContext(DbContextOptions<EmployDBContext> options) : base(options)
        {
        }
        //OnConfiguring() method is used to select and configure the data source
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employ>().ToTable("Employ1");
        }

        public DbSet<Employ> Employees { get; set; }
    }
}
