using ECommerce.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Products, int>
    {
        Task<List<Products>> GetProductsWithCategories();
    }
}
