using ECommerce.Domain.Entities.Category;
using ECommerce.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services.Category
{
    public interface ICategoryService
    {
        Task<List<Categories>> GetAllCategories();
        Task<Categories> CreateCategory(Categories category);

        Task<Categories> GetCategoryById(int id);
    }
}
