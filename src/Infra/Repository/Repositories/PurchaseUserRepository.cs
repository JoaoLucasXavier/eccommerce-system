using Domain.Interfaces.PurchaseUserInterface;
using Entities;
using static Infra.Repository.Generics.GenericsRepository;

namespace Infra.Repository.Repositories
{
    public class PurchaseUserRepository : GenericRepository<PurchaseUser>, IPurchaseUser
    {

    }
}
