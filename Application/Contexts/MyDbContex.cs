using Microsoft.EntityFrameworkCore;
using Entities;

namespace Application.Contexts
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Game> Game { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=GamersCastle;user=root;password=Shweta@123",
               new MySqlServerVersion(new Version(8, 0, 21)));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<User>().HasMany(u => u.Orders).WithOne(o => o.user);
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
            //modelBuilder.Entity<Order>().HasMany(o => o.Products).WithMany(p => p.Orders);

            modelBuilder.Entity<Product>().HasKey(o => o.ProductId);
            modelBuilder.Entity<Product>().HasMany(p => p.Orders).WithOne(o => o.product);
            modelBuilder.Entity<Game>().HasKey(g => g.GameId); // Primary Key
            modelBuilder.Entity<Game>().Property(g => g.Title).HasColumnName("game_title"); // Column Name Mapping
            modelBuilder.Entity<Game>().Property(g => g.Description).HasMaxLength(500); // Description Length
            modelBuilder.Entity<Game>().Property(g => g.ImageUrl).HasColumnName("image_url"); // Column Name Mapping
            modelBuilder.Entity<Game>().Property(g => g.TrailerUrl).HasColumnName("trailer_url"); // Column Name Mapping
        }
    }
}
