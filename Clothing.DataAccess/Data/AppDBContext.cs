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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Wedding", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Traditional", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Sports Wear", DisplayOrder = 3},
                  new Category { Id = 4, Name = "Summer Wear", DisplayOrder = 4 }, 
                    new Category { Id = 5, Name = "Winter Wear", DisplayOrder = 5 },
                      new Category { Id = 6, Name = "Baby Wear", DisplayOrder = 6 }
                    
                );
        }
    }
}
