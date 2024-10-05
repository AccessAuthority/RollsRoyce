using Microsoft.EntityFrameworkCore;

namespace RollsRoyce.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<ContactForm> ContactForm { get; set; }
        public DbSet<CarForm> CarForm { get; set; }
        public DbSet<Admin> Admin { get; set; }
    }

}
