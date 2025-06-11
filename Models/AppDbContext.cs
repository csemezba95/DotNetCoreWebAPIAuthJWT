using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebAPIAuthJWT.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RevokedToken> RevokedTokens { get; set; }

    }
}
