using Microsoft.EntityFrameworkCore;

namespace Home.Api
{
    public class HomeDbContext : DbContext
    {
        public HomeDbContext(DbContextOptions<HomeDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .HasOne(p => p.Home)
                .WithMany(p => p.Rooms);

            modelBuilder.Entity<Window>()
                .HasOne(p => p.Room)
                .WithMany(p => p.Windows);

            modelBuilder.Entity<LightBulb>()
                .HasOne(p => p.Room)
                .WithMany(p => p.LightBulbs);

            modelBuilder.Entity<Door>()
                .HasOne(p => p.Room)
                .WithMany(p => p.Doors);
        }

        public DbSet<Home> Homes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Window> Windows { get; set; }
        public DbSet<LightBulb> LightBulbs { get; set; }
    }
}
