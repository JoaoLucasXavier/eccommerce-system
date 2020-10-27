using System.Threading.Tasks;
using Domain.Interfaces.PurchaseUserInterface;
using Entities;
using Microsoft.EntityFrameworkCore;
using sfm.Infra.Configuration;
using static Infra.Repository.Generics.GenericsRepository;

namespace Infra.Repository.Repositories
{
    public class PurchaseUserRepository : GenericRepository<PurchaseUser>, IPurchaseUser
    {
        private readonly DbContextOptions<ECommerceContext> _OptionsBuilder;

        public PurchaseUserRepository()
        {
            _OptionsBuilder = new DbContextOptions<ECommerceContext>();
        }

        public async Task<int> UserCartProductQuantity(string userId)
        {
            using var db = new ECommerceContext(_OptionsBuilder);
            return await db.PurchasesUser.CountAsync(c => c.UserId == userId);
        }
    }
}
