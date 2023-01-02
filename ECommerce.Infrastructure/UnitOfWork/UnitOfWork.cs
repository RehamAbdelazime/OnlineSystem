using ECommerce.Domain.Entities.Category;
using ECommerce.Domain.Entities.Product;
using ECommerce.Infrastructure.Repository.Impl;
using ECommerce.Infrastructure.Repository.Interfaces;
using ECommerce.Migrations.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ILogger _logger;
        private readonly OShopDbContext _context;

        public UnitOfWork(OShopDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Products = new ProductRepository (_context, _logger);
            Categories = new Repository<Categories, int>(_context, _logger);

        }
        public IProductRepository Products { get; private set; }
        public IRepository<Categories, int> Categories { get; private set; }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
