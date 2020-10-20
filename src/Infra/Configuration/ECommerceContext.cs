using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace sfm.Infra.Configuration
{
    public class ECommerceContext : IdentityDbContext<IdentityUser>
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options) { }

        public DbSet<Product> Products { set; get; }
        public DbSet<PurchaseUser> PurchasesUser { set; get; }
        public DbSet<ApplicationUser> ApplicationUsers { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer(GetConnectionString());
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Informa ao identity qual é a PK ao subscrever a entidade 'ApplicationUser'
            modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            base.OnModelCreating(modelBuilder);
        }

        private string GetConnectionString()
        {
            return "Server=localhost;DataBase=ECommerceSystem;Uid=SA;Pwd=@Ss170580;";
        }
    }
}
