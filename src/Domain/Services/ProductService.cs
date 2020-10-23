using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Interfaces.ProductInterface;
using Domain.Interfaces.ServicesInterface;
using Entities;

namespace Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProduct _IProduct;

        public ProductService(IProduct iProduct)
        {
            _IProduct = iProduct;
        }

        public async Task AddProduct(Product product)
        {
            var validName = product.ValidateStringProperty(product.Name, "Name");
            var validValue = product.ValidateDecimalProperty(product.Value, "Value");
            var validStockQuantity = product.ValidateIntegerProperty(product.StockQuantity, "StockQuantity");
            if (validName && validValue && validStockQuantity)
            {
                product.DateRegister = DateTime.Now;
                product.ChangeDate = DateTime.Now;
                product.State = true;
                await _IProduct.Add(product);
            }
        }

        public async Task UpdateProduct(Product product)
        {
            var validName = product.ValidateStringProperty(product.Name, "Name");
            var validValue = product.ValidateDecimalProperty(product.Value, "Value");
            var validStockQuantity = product.ValidateIntegerProperty(product.StockQuantity, "StockQuantity");
            if (validName && validValue && validStockQuantity)
            {
                product.ChangeDate = DateTime.Now;
                await _IProduct.Update(product);
            }
        }

        public async Task<List<Product>> ListProductsWithStock()
        {
            return await _IProduct.ProductList(p => p.StockQuantity > 0);
        }
    }
}
