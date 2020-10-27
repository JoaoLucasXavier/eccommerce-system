using System.Threading.Tasks;
using Entities;

namespace Application.Interfaces
{
    public interface PurchaseUserAppInterface : GenericAppInterface<PurchaseUser>
    {
        public Task<int> UserCartProductQuantity(string userId);
    }
}
