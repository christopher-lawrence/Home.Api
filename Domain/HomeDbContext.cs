using Microsoft.EntityFrameworkCore;

namespace Home.Api
{
    public class HomeDbContext : DbContext
    {
        public HomeDbContext(DbContextOptions<HomeDbContext> options) : base(options)
        { }

        //TODO: Add relationships via Fluent API??

        public DbSet<Home> Homes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Window> Windows { get; set; }
        public DbSet<LightBulb> LightBulbs { get; set; }
    }
}
