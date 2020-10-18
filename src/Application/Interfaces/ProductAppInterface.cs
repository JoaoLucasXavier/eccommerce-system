using System.Threading.Tasks;
using Entities;

namespace Application.Interfaces
{
    public interface ProductAppInterface : GenericAppInterface<Product>
    {
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
    }
}
