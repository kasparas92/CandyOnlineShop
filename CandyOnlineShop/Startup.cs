using CandyOnlineShop.Models;
using CandyOnlineShop.Models.DataModels;
using CandyOnlineShop.Models.Entity;
using CandyOnlineShop.Models.Interfaces;
using CandyOnlineShop.Models.Repositories;
using CandyOnlineShop.Models.Repositories.Interfaces;
using CandyOnlineShop.Models.Services;
using CandyOnlineShop.Models.Services.Interfaces;
using CandyOnlineShop.Repositories;
using CandyOnlineShop.Repositories.Interfaces;
using CandyOnlineShop.Services;
using CandyOnlineShop.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CandyOnlineShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICandyRepository, CandyRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICandyService, CandyService>();
            services.AddScoped<IShoppingCartItemRepository, ShoppingCartItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddDbContext<CandyContext>(options => 
                                                    options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<CandyContext>();
            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddScoped(x => ShoppingCart.GetCart(x));
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSession();

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
