using System.Threading.Tasks;
using Domain.Interfaces.Generics;
using Entities;

namespace Domain.Interfaces.PurchaseUserInterface
{
    public interface IPurchaseUser : IGeneric<PurchaseUser>
    {
        public Task<int> UserCartProductQuantity(string userId);
    }
}
