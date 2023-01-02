using ECommerce.Core.Services.Category;
using ECommerce.Domain.Entities.Category;
using ECommerce.Domain.Entities.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _categoryService.GetAllCategories();

                return Ok( categories );
            }
            catch (Exception ex)
            {
                return BadRequest(new { Errors = new List<string>() { ex.ToString() }, Success = false });
            }

        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            try
            {
                var categories = await _categoryService.GetCategoryById(id);

                if (categories == null)
                {
                    return NotFound();
                }
                
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Errors = new List<string>() { ex.ToString() }, Success = false });
            }

        }
        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(Categories product)
        {
            try
            {
                return Ok(new { result = await _categoryService.CreateCategory(product) });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Errors = ex.Message.ToString()
                });
            }

        }
        [HttpPost]
        [Route("EditCategory")]
        public async Task<IActionResult> EditCategory(Categories product)
        {
            try
            {
                return Ok(new { result = await _categoryService.CreateCategory(product) });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Errors = ex.Message.ToString()
                });
            }

        }

    }
}
