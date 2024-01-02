using DeltaCore.Models;

namespace DeltaCore.ServiceLayer
{
    public interface IProductService
    {
        Task<Product> CreateProduct(Product product);
        Task<List<Product>> GetProducts();
        Task<Product> GetAsync(int? productId);
    }
}
