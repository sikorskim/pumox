using Microsoft.EntityFrameworkCore;

namespace Pumox.Models
{
    public class PumoxContext : DbContext
    {
        public PumoxContext(DbContextOptions<PumoxContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}