using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Interfaces.ProductInterface;
using Domain.Interfaces.ServicesInterface;
using Entities;

namespace Application.OpenApp
{
    public class ProductApp : ProductAppInterface
    {
        IProduct _IProduct;
        IProductService _IProductService;

        public ProductApp(IProduct iProduct, IProductService iProductService)
        {
            _IProduct = iProduct;
            _IProductService = iProductService;
        }

        public async Task Add(Product Object)
        {
            await _IProduct.Add(Object);
        }

        public async Task Delete(Product Object)
        {
            await _IProduct.Delete(Object);
        }

        public async Task<Product> GetEntityById(Guid Id)
        {
            return await _IProduct.GetEntityById(Id);
        }

        public async Task<List<Product>> List()
        {
            return await _IProduct.List();
        }

        public async Task Update(Product Object)
        {
            await _IProduct.Update(Object);
        }

        public async Task AddProduct(Product product)
        {
            await _IProductService.AddProduct(product);
        }

        public async Task UpdateProduct(Product product)
        {
            await _IProductService.UpdateProduct(product);
        }

        public async Task<List<Product>> ListUserProducts(string userId)
        {
            return await _IProduct.ListUserProducts(userId);
        }
    }
}
