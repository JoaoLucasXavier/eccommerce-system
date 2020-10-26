using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Interfaces.PurchaseUserInterface;
using Entities;

namespace Application.OpenApp
{
    public class PurchaseUserApp : PurchaseUserAppInterface
    {
        private readonly IPurchaseUser _IPurchaseUser;

        public PurchaseUserApp(IPurchaseUser iPurchaseUser)
        {
            _IPurchaseUser = iPurchaseUser;
        }

        public async Task Add(PurchaseUser Object)
        {
            await _IPurchaseUser.Add(Object);
        }

        public async Task Delete(PurchaseUser Object)
        {
            await _IPurchaseUser.Delete(Object);
        }

        public async Task<PurchaseUser> GetEntityById(Guid Id)
        {
            return await _IPurchaseUser.GetEntityById(Id);
        }

        public async Task<List<PurchaseUser>> List()
        {
            return await _IPurchaseUser.List();
        }

        public async Task Update(PurchaseUser Object)
        {
            await _IPurchaseUser.Update(Object);
        }
    }
}
