using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.ProductInterface;
using Entities;
using Microsoft.EntityFrameworkCore;
using sfm.Infra.Configuration;
using static Infra.Repository.Generics.GenericsRepository;

namespace Infra.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProduct
    {
        private readonly DbContextOptions<ECommerceContext> _optionsBuilder;

        public ProductRepository()
        {
            _optionsBuilder = new DbContextOptions<ECommerceContext>();
        }

        public async Task<List<Product>> ListUserProducts(string userId)
        {
            using var db = new ECommerceContext(_optionsBuilder);
            return await db.Products.Where(p => p.UserId == userId).AsNoTracking().ToListAsync();
        }
    }
}
