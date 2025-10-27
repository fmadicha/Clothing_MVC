using Clothing.Models;
using Microsoft.EntityFrameworkCore;

namespace Clothing.DataAccess.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options) 
        {
                
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Men", Description = "Men's clothing collection" },
                new Category { Id = 2, Name = "Women", Description = "Women's fashion and apparel" },
                new Category { Id = 3, Name = "Kids", Description = "Children's wear" }
            );
            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Men’s T-Shirt",
                    Description = "Cotton slim-fit T-shirt",
                    ListPrice = 249.99m,
                    Price = 229.99m,
                    Price50 = 209.99m,
                    CategoryId = 1,
                    ImageUrl = "/images/mens-tshirt.jpg",
                    Size = "M",
                    Color = "Black",
                    Stock = 30
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Women’s Denim Jacket",
                    Description = "Blue denim jacket with front pockets",
                    ListPrice = 200.00m,
                    Price = 180.00m,
                    Price50 = 160.00m,
                    CategoryId = 2,
                    ImageUrl = "/images/womens-denim-jacket.jpg",
                    Size = "L",
                    Color = "Blue",
                    Stock = 15
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Kids’ Hoodie",
                    Description = "Warm fleece hoodie for kids",
                    ListPrice = 249.99m,
                    Price = 229.99m,
                    Price50 = 209.99m,
                    CategoryId = 3,
                    ImageUrl = "/images/kids-hoodie.jpg",
                    Size = "S",
                    Color = "Red",
                    Stock = 25
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Men’s Formal Shirt",
                    Description = "White long-sleeve formal shirt",
                    ListPrice = 299.99m,
                    Price = 279.99m,
                    Price50 = 249.99m,
                    CategoryId = 1,
                    ImageUrl = "/images/mens-formal-shirt.jpg",
                    Size = "L",
                    Color = "White",
                    Stock = 20
                },
                new Product
                {
                    ProductId = 5,
                    Name = "Women’s Summer Dress",
                    Description = "Light floral dress for warm days",
                    ListPrice = 349.99m,
                    Price = 329.99m,
                    Price50 = 309.99m,
                    CategoryId = 2,
                    ImageUrl = "/images/womens-dress.jpg",
                    Size = "M",
                    Color = "Yellow",
                    Stock = 10
                }
            );
        }
    }
}
