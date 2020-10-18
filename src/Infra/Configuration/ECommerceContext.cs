using Entities;
using Microsoft.EntityFrameworkCore;

namespace sfm.Infra.Configuration
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options) { }

        public DbSet<Product> Products { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer(GetConnectionString());
            base.OnConfiguring(optionsBuilder);
        }

        private string GetConnectionString()
        {
            return "Server=localhost;DataBase=ECommerceSystem;Uid=SA;Pwd=@Ss170580;";
        }
    }
}
