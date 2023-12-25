using APIDemo.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace APIDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Shirt> Shirts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // data seeding
            modelBuilder.Entity<Shirt>().HasData(
                new Shirt { ShirtId = 1, Brand = "My Brand", Color = "Red", Gender = "Men", Price = 30, Size = 10 },
            new Shirt { ShirtId = 2, Brand = "My Brand", Color = "Blue", Gender = "Men", Price = 45, Size = 42 },
            new Shirt { ShirtId = 3, Brand = "My Brand", Color = "White", Gender = "Men", Price = 61, Size = 55 },
            new Shirt { ShirtId = 4, Brand = "My Brand", Color = "Black", Gender = "Men", Price = 22, Size = 33 });
        }
    }
}
