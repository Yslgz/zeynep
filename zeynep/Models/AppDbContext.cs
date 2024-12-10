using Microsoft.EntityFrameworkCore;

namespace zeynep.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Survey> Surveys{ get; set; } 
        public DbSet<Anketler> Anketlers{ get; set; }

    }
}
