using AutoMapper;
using ECommerce.Core.Services.Category;
using ECommerce.Core.Services.Product;
using ECommerce.Infrastructure.UnitOfWork;
using ECommerce.Migrations.Persistence;
using EntityFrameworkCore.UseRowNumberForPaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<DbContext, OShopDbContext>();
            string connectionString = Configuration.GetConnectionString("mConnectionString").Trim();

            services.AddDbContext<OShopDbContext>(options => options.UseSqlServer(connectionString, builder => builder.UseRowNumberForPaging()));
            return services;
        }


        public static IServiceCollection AddECommerceRefs(this IServiceCollection services)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProducService, ProducService>();

            return services;
        }

    }
}
