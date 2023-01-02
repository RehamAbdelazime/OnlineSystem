using AutoMapper;
using ECommerce.Core.Services.Product;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Entities.Product;
using ECommerce.Infrastructure.DTO.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProducService _producService;
        private readonly IMapper _mapper;

        public ProductController(IProducService producService, IMapper mapper)
        {
            _producService = producService;
            _mapper =  mapper;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {            
            try
            {
                var products = await _producService.GetAllProducts();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Errors = new List<string>() { ex.ToString() }, Success = false });
            }

        }

        [HttpGet]
        [Route("GetAllProductsPages")]
        public async Task<IActionResult> GetAllProductsPages([FromQuery] PagingParameters productParameters)
        {
            
            if (productParameters.PageNumber <= 0)
            {
                return BadRequest(new { error = "this page number is not allowed (<=0)" });
            }
            else
            {
                try
                {                                      
                    if (productParameters.PageSize > 25 || productParameters.PageSize < 0) productParameters.PageSize = 25;
                    var pagedUsers = await _producService.GetProductsPages(productParameters);
                    //var products = _mapper.Map<List<ProductDTO>>(pagedUsers.Entities);
                    return Ok(pagedUsers.Entities);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { Errors = new List<string>() { ex.ToString() }, Success = false });
                }

            }
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(Products product)
        {
            try
            {
                return Ok(await _producService.CreateProduct(product));
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
