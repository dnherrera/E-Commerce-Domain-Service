using AutoMapper;
using ECommerce.Api.Products.Db;
using ECommerce.Api.Products.Interfaces;
using ECommerce.Api.Products.Profiles;
using ECommerce.Api.Products.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ECommerce.Api.Products
{
    /// <summary>
    /// The Start Up
    /// </summary>
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry("8ea3060a-8e0e-4368-830a-48b2d4116c97");
            services.AddControllers();
            services.AddScoped<IProductsProvider, ProductsProvider>();
            services.AddAutoMapper(typeof(ProductProfile).Assembly);
            services.AddDbContext<ProductsDbContext>(options => options.UseInMemoryDatabase("Products"));
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}