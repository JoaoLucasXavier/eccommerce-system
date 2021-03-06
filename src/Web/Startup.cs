using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using sfm.Infra.Configuration;
using Domain.Interfaces.Generics;
using static Infra.Repository.Generics.GenericsRepository;
using Domain.Interfaces.ProductInterface;
using Infra.Repository.Repositories;
using Application.Interfaces;
using Application.OpenApp;
using Domain.Interfaces.ServicesInterface;
using Domain.Services;
using Entities;
using Domain.Interfaces.PurchaseUserInterface;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ECommerceContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ECommerceContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            /* Add dependencies injection */
            services.AddSingleton(typeof(IGeneric<>), typeof(GenericRepository<>));
            services.AddSingleton<IProduct, ProductRepository>();
            services.AddSingleton<IPurchaseUser, PurchaseUserRepository>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<ProductAppInterface, ProductApp>();
            services.AddSingleton<PurchaseUserAppInterface, PurchaseUserApp>();

            services.AddDbContext<RazorPagesMovieContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("RazorPagesMovieContext")));
            /* END - Add dependencies injection */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
