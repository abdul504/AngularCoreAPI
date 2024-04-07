using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employee { get; set; }

      
    }
}
