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
            if (validName && validValue)
            {
                product.State = true;
                await _IProduct.Add(product);
            }
        }

        public async Task UpdateProduct(Product product)
        {
            var validName = product.ValidateStringProperty(product.Name, "Name");
            var validValue = product.ValidateDecimalProperty(product.Value, "Value");
            if (validName && validValue) await _IProduct.Update(product);
        }
    }
}
