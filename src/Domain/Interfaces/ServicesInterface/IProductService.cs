using System.Threading.Tasks;
using Entities;

namespace Domain.Interfaces.ServicesInterface
{
    public interface IProductService
    {
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
    }
}
