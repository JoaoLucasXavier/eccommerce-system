// using Entities;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using Presentation.Areas.Identity.Data;

// [assembly: HostingStartup(typeof(Presentation.Areas.Identity.IdentityHostingStartup))]
// namespace Presentation.Areas.Identity
// {
//     public class IdentityHostingStartup : IHostingStartup
//     {
//         public void Configure(IWebHostBuilder builder)
//         {
//             builder.ConfigureServices((context, services) => {
//                 services.AddDbContext<ECommerceContext>(options =>
//                     options.UseSqlServer(
//                         context.Configuration.GetConnectionString("ECommerceContextConnection")));

//                 services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
//                     .AddEntityFrameworkStores<ECommerceContext>();
//             });
//         }
//     }
// }
