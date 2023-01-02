using ECommerce.Domain.Entities;
using ECommerce.Domain.Entities.Category;
using ECommerce.Domain.Entities.Product;
using ECommerce.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services.Product
{
    public class ProducService : IProducService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProducService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }

        public async Task<List<Products>> GetAllProducts()
        {
            var products = await _unitOfWork.Products.GetProductsWithCategories();
            return products.ToList();
        }

        public async Task<PagedEntities<Products>> GetProductsPages(PagingParameters userParameters)
        {
            var products = _unitOfWork.Products.GetProductsWithCategories().Result.ToList();

            var paggdProducts = await _unitOfWork.Products.GetByPage(products, userParameters.PageNumber, userParameters.PageSize, orderBy: on => (on.OrderBy(x => x.EnglishName)));
            return paggdProducts;
        }

        public async Task<Products> GetProductById(int id)
        {
            var product = _unitOfWork.Products.FindAsync(x => x.ID == id).Result.FirstOrDefault();
            return product;
        }

        public async Task<Products> CreateProduct(Products product)
        {
            //Check if the item already exists              
            try
            {

                var newProduct = await _unitOfWork.Products.CreateAsync(product);
                await _unitOfWork.CommitAsync();
                //check if the item has been added successfully
                if (newProduct != null)
                {
                    return newProduct;
                }
                else
                {
                    throw new Exception($"the item {newProduct.ArabicName} has not been added");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}