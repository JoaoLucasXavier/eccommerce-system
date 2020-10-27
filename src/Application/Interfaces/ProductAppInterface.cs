using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Application.Interfaces
{
    public interface ProductAppInterface : GenericAppInterface<Product>
    {
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task<List<Product>> ListUserProducts(string userId);
        Task<List<Product>> ListProductsWithStock();
        Task<List<Product>> ListProductsUserCart(string userId);
        Task<Product> GetProductCart(Guid productCartId);
    }
}
