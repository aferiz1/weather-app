using Microsoft.EntityFrameworkCore;
namespace WeatherAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<WeatherSnapshots> WeatherSnapshots { get; set; }
        public DbSet<City> Cities { get; set; }  
    }
}
