using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Interfaces.Generics;
using Entities;

namespace Domain.Interfaces.ProductInterface
{
    public interface IProduct : IGeneric<Product>
    {
        Task<List<Product>> ListUserProducts(string userId);
        Task<List<Product>> ProductList(Expression<Func<Product, bool>> expProduct);
        Task<List<Product>> ListProductsUserCart(string userId);
        Task<Product> GetProductCart(Guid productCartId);
    }
}
