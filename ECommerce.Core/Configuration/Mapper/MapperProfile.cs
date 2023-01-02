using AutoMapper;
using ECommerce.Domain.Entities.Product;
using ECommerce.Infrastructure.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Configuration.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {            
            CreateMap<ProductDTO, Products>().ReverseMap();        
        }
    }
}
