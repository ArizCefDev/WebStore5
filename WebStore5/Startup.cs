using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore5.Models;

namespace WebStore5
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
            //Services
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IBeeftService, BeefService>();
            services.AddScoped<IBreadService, BreadService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICerealService, CerealService>();
            services.AddScoped<IChickenService, ChickenService>();
            services.AddScoped<IClearProductService, ClearProductService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IDiscountLitreService, DiscountLitreService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IFishService, FishService>();
            services.AddScoped<IFrozenNonvegService, FrozenNonvegService>();
            services.AddScoped<IFrozenSnacksService, FrozenSnackService>();
            services.AddScoped<IFruitService, FruitService>();
            services.AddScoped<IHouseHoldService, HouseHoldService>();
            services.AddScoped<IJuiceDrinkService, JuiceDrinkService>();
            services.AddScoped<ISoftDrinkService, SoftDrinkService>();
            services.AddScoped<IPetFoodService, PetFoodService>();
            services.AddScoped<IPosterService, PosterService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IServicesService, ServiceService>();
            services.AddScoped<ISweetService, SweetService>();
            services.AddScoped<IVegaTableService, VegatableService>();

            //EF
            services.AddScoped<IAboutDal, EfAboutRepository>();
            services.AddScoped<IBeefDal, EfBeefRepository>();
            services.AddScoped<IBreadDal, EfBreadRepository>();
            services.AddScoped<ICategoryDal, EfCategoryRepository>();
            services.AddScoped<ICerealDal, EfCerealRepository>();
            services.AddScoped<IChickenDal, EfChickenRepository>();
            services.AddScoped<IClearProductDal, EfClearProductRepository>();
            services.AddScoped<IContactDal, EfContactRepository>();
            services.AddScoped<IDiscountDal, EfDiscountRepository>();
            services.AddScoped<IDiscountLitreDal, EfDiscountLitreRepository>();
            services.AddScoped<IEmployeeDal, EfEmployeeRepository>();
            services.AddScoped<IFishDal, EfFishRepository>();
            services.AddScoped<IFrozenNonvegDal, EfFrozenNonvegRepository>();
            services.AddScoped<IFrozenSnacksDal, EfFrozenSnackRepository>();
            services.AddScoped<IFruitDal, EfFruitRepository>();
            services.AddScoped<IHouseHoldDal, EfHouseHoldRepository>();
            services.AddScoped<IJuiceDrinkDal, EfJuiceDrinkRepository>();
            services.AddScoped<ISoftDrinkDal, EfSoftDrinkRepository>();
            services.AddScoped<IPetFoodDal, EfPetFoodRepository>();
            services.AddScoped<IPosterDal, EfPosterRepository>();
            services.AddScoped<IProductDal, EfProductRepository>();
            services.AddScoped<IServiceDal, EfServiceRepository>();
            services.AddScoped<ISweetDal, EfSweetRepository>();
            services.AddScoped<IVegatableDal, EfVegatableRepository>();

            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>()
                .AddErrorDescriber<IdentityValidator>()
                .AddEntityFrameworkStores<Context>();

            services.AddControllersWithViews();

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Default}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
