using Microsoft.EntityFrameworkCore;
using VanceSampleApi.Data;
using VanceSampleApi.Models;
using VanceSampleApi.Repositories.Interfaces;

namespace VanceSampleApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context) 
        {
            _context = context;
            _context.Database.EnsureCreated(); //just for testing with the in-memory db
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            return product;
        }

        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await SaveChangesAsync();
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var existingProduct = await GetProductByIdAsync(product.Id);

            if (existingProduct == null)
                return false;

            _context.Entry(existingProduct).CurrentValues.SetValues(product);

            return await SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                _context.Products.Remove(product);
                await SaveChangesAsync();
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
