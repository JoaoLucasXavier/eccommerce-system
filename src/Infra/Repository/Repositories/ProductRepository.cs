using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Interfaces.ProductInterface;
using Entities;
using Entities.Enums;
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

        public async Task<List<Product>> ProductList(Expression<Func<Product, bool>> expProduct)
        {
            using var db = new ECommerceContext(_optionsBuilder);
            return await db.Products.Where(expProduct).AsNoTracking().ToListAsync();
        }

        public async Task<List<Product>> ListProductsUserCart(string userId)
        {
            using var db = new ECommerceContext(_optionsBuilder);
            return await (from p in db.Products
                join pu in db.PurchasesUser on p.Id equals pu.ProductId
                where pu.UserId.Equals(userId) && pu.PurchaseStatus == PurchaseStatusEmum.InCart
                select new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Observation = p.Observation,
                    Value = p.Value,
                    PurchaseQuantity = pu.PurchaseAmount,
                    ProductCartId = pu.Id
                }).AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetProductCart(Guid productCartId)
        {
            using var db = new ECommerceContext(_optionsBuilder);
            return await (from p in db.Products
                join pu in db.PurchasesUser on p.Id equals pu.ProductId
                where pu.Id.Equals(productCartId) && pu.PurchaseStatus == PurchaseStatusEmum.InCart
                select new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Observation = p.Observation,
                    Value = p.Value,
                    PurchaseQuantity = pu.PurchaseAmount,
                    ProductCartId = pu.Id
                }).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
