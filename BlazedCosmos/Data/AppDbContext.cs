using Microsoft.EntityFrameworkCore;
using BlazedCosmos.Models;

namespace BlazedCosmos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Galaxy Print", Description = "A stunning galaxy art print", Price = 2000, ImageUrl = "/images/1.jpg" },
                new Product { Id = 2, Name = "Cosmic Nebula", Description = "A vibrant nebula art print", Price = 3000, ImageUrl = "/images/2.jpg" },
                new Product { Id = 3, Name = "Starry Night", Description = "A mesmerizing starry night print", Price = 2500, ImageUrl = "/images/3.jpg" },
                new Product { Id = 4, Name = "Solar Flare", Description = "A dramatic solar flare art print", Price = 2100, ImageUrl = "/images/4.jpg" },
                new Product { Id = 5, Name = "Aurora Borealis", Description = "A beautiful aurora borealis print", Price = 1000, ImageUrl = "/images/5.jpg" },
                new Product { Id = 6, Name = "Milky Way", Description = "A breathtaking Milky Way art print", Price = 1500, ImageUrl = "/images/6.jpg" },
                new Product { Id = 7, Name = "Planetary Orbit", Description = "A unique planetary orbit print", Price = 1800, ImageUrl = "/images/7.jpg" },
                new Product { Id = 8, Name = "Black Hole", Description = "A mysterious black hole art print", Price = 2000m, ImageUrl = "/images/8.jpg" }
            );
        }
    }
}