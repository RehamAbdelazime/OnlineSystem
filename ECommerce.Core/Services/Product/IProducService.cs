using ECommerce.Domain.Entities;
using ECommerce.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services.Product
{
    public interface IProducService
    {
        Task<List<Products>> GetAllProducts();
        Task<PagedEntities<Products>> GetProductsPages(PagingParameters userParameters);
        Task<Products> GetProductById(int id);
        Task<Products> CreateProduct(Products product);
    }
}
