using VanceSampleApi.Models;

namespace VanceSampleApi.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}