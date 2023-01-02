using ECommerce.Domain.Entities.Product;
using ECommerce.Infrastructure.Repository.Interfaces;
using ECommerce.Migrations.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repository.Impl
{
    public class ProductRepository : Repository<Products, int>, IProductRepository
    {
        public ProductRepository(OShopDbContext context, ILogger logger) : base(context, logger)
        {
        }
        public async Task<List<Products>> GetProductsWithCategories()
        {
            return await _entities.Include(x => x.ProductCategory)
                                  .AsNoTracking()
                                  .ToListAsync();
        }
    }
}
