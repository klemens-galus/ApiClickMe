using Microsoft.EntityFrameworkCore;

namespace ApiClickMe.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option) { }
        public DbSet<GAMEH> GAMEH { get; set; } 
        public DbSet<GAMED> GAMED { get; set; }

    }
}
