using Domain.Interfaces.ProductInterface;
using Entities;
using static Infra.Repository.Generics.GenericsRepository;

namespace Infra.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProduct
    {

    }
}
