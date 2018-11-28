using Home.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Home.Api.Domain
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
            modelBuilder.Entity<Room>()
                .Property(p => p.HomeId)
                .IsRequired();

            modelBuilder.Entity<Room>()
                .HasMany(p => p.Colors)
                .WithOne();

            modelBuilder.Entity<Window>()
                .HasOne(p => p.Room)
                .WithMany(p => p.Windows);
            modelBuilder.Entity<Window>()
                .Property(p => p.RoomId)
                .IsRequired();
            modelBuilder.Entity<Window>()
                .HasOne(p => p.Color)
                .WithOne();

            modelBuilder.Entity<LightBulb>()
                .HasOne(p => p.Room)
                .WithMany(p => p.LightBulbs);
            modelBuilder.Entity<LightBulb>()
                .Property(p => p.RoomId)
                .IsRequired();

            modelBuilder.Entity<Door>()
                .HasOne(p => p.Room)
                .WithMany(p => p.Doors);
            modelBuilder.Entity<Door>()
                .Property(p => p.RoomId)
                .IsRequired();
            modelBuilder.Entity<Door>()
                .HasOne(p => p.Color)
                .WithOne();

            modelBuilder.Entity<Floor>()
                .HasOne(p => p.Room)
                .WithOne(p => p.Floor);
            modelBuilder.Entity<Floor>()
                .Property(p => p.RoomId)
                .IsRequired();
            modelBuilder.Entity<Floor>()
                .HasOne(p => p.Color)
                .WithOne();
        }

        public DbSet<Models.Home> Homes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Window> Windows { get; set; }
        public DbSet<LightBulb> LightBulbs { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Color> Colors { get; set; }
    }
}
