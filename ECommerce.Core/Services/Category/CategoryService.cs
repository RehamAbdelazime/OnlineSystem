using ECommerce.Domain.Entities.Category;
using ECommerce.Infrastructure.UnitOfWork;

namespace ECommerce.Core.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Categories>> GetAllCategories()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            return categories.ToList();
        }

        public async Task<Categories> GetCategoryById(int id)
        {
            var categories = _unitOfWork.Categories.FindAsync(x => x.ID == id).Result.FirstOrDefault();
            return categories;
        }

        public async Task<Categories> CreateCategory(Categories category)
        {
            //Check if the category already exists              
            try
            {
                var newCategory = await _unitOfWork.Categories.CreateAsync(category);
                await _unitOfWork.CommitAsync();
                //check if the item has been added successfully
                if (newCategory != null)
                {
                    return newCategory;
                }
                else
                {
                    throw new Exception($"the category {newCategory.Name} has not been added");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Categories> EditCategory(Categories category)
        {
            //Check if the category already exists              
            try
            {
                var newCategory = await _unitOfWork.Categories.CreateAsync(category);
                await _unitOfWork.CommitAsync();
                //check if the item has been added successfully
                if (newCategory != null)
                {
                    return newCategory;
                }
                else
                {
                    throw new Exception($"the category {newCategory.Name} has not been added");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
