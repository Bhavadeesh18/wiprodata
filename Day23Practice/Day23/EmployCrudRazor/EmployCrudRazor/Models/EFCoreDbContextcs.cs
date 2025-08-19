using Microsoft.EntityFrameworkCore;

namespace EmployCrudRazor.Models
{
    public class EFCoreDbContextcs : DbContext
    {
        //Constructor calling the Base DbContext Class Constructor
        public EFCoreDbContextcs(DbContextOptions<EFCoreDbContextcs> options) : base(options)
        {

        }
        //OnConfiguring() method is used to select and configure the data source
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-9L94JKC;Database=wiprojuly;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employ>().ToTable("Employ");
        }

        public DbSet<Employ> Employees { get; set; }
    }
}   
