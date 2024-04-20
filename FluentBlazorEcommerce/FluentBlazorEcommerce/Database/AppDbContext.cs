using FluentBlazorEcommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace FluentBlazorEcommerce.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "High-Performance Laptop", Price = 999.99m, Description = "High-performance laptop for gaming and productivity." },
                new Product { Id = 2, Name = "Latest Smartphone", Price = 699.99m, Description = "Latest smartphone with advanced features and high-resolution camera." },
                new Product { Id = 3, Name = "Fitness Smartwatch", Price = 249.99m, Description = "Fitness tracker with heart rate monitor and GPS functionality." },
                new Product { Id = 4, Name = "Next-Gen Gaming Console", Price = 499.99m, Description = "Next-gen gaming console with immersive gaming experience." },
                new Product { Id = 5, Name = "Noise-Canceling Headphones", Price = 149.99m, Description = "Noise-canceling wireless headphones with long battery life." },
                new Product { Id = 6, Name = "Ultra-HD Monitor", Price = 399.99m, Description = "Ultra-high-definition monitor for crystal-clear visuals." },
                new Product { Id = 7, Name = "Powerful Graphics Card", Price = 799.99m, Description = "Powerful graphics card for smooth gaming and video rendering." },
                new Product { Id = 8, Name = "Mechanical Keyboard", Price = 129.99m, Description = "Mechanical keyboard with customizable RGB lighting." }
            );

            // Seed data for Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Laptops and Notebooks" },
                new Category { Id = 2, Name = "Smartphones and Mobile Devices" },
                new Category { Id = 3, Name = "Wearable Technology" },
                new Category { Id = 4, Name = "Gaming Consoles and Accessories" },
                new Category { Id = 5, Name = "Computer Accessories and Peripherals" },
                new Category { Id = 6, Name = "Monitors and Displays" },
                new Category { Id = 7, Name = "Graphics Cards and Video Devices" },
                new Category { Id = 8, Name = "Keyboards and Mice" }
            );

            // Seed data for Inventories
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { Id = 1, ProductId = 1, Quantity = 10 },
                new Inventory { Id = 2, ProductId = 2, Quantity = 15 }
                // Add more inventory data as needed
            );

            // Seed data for Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "Saeko", Email = "saetea24.com" },
                new User { Id = 2, Username = "Ren", Email = "renarakawa42.com" }
                // Add more user data as needed
            );

            // Seed data for ShoppingCarts
            modelBuilder.Entity<ShoppingCart>().HasData(
                new ShoppingCart { Id = 1, UserId = 1 },
                new ShoppingCart { Id = 2, UserId = 2 }
                // Add more shopping cart data as needed
            );
        }
    }
}