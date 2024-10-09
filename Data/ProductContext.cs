using Microsoft.EntityFrameworkCore;
using VanceSampleApi.Models;

namespace VanceSampleApi.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Console.WriteLine("OnModelCreating, seeding data...");

            //Dummy data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product 1", Price = 9.99m , Description = "Product 1"},
                new Product { Id = 2, Name = "Product 2", Price = 19.99m, Description = "Product 2" }
            );
        }
    }
}
