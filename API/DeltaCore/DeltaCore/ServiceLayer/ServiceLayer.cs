using DeltaCore.Models;
using Microsoft.EntityFrameworkCore;

namespace DeltaCore.ServiceLayer
{
    public class ServiceLayer : IProductService
    {
        private readonly ProductContext _product;

        public ServiceLayer(ProductContext product)
        {
            _product = product;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await _product.AddAsync(product);
            await _product.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _product.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(int? productId)
        {
            if (productId == null)
            {
                return null;
            }
            return await _product.Products.FindAsync(productId);
        }
    }
}