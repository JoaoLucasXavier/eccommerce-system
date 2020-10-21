using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.Generics;
using Entities;

namespace Domain.Interfaces.ProductInterface
{
    public interface IProduct : IGeneric<Product>
    {
        Task<List<Product>> ListUserProducts(string userId);
    }
}
