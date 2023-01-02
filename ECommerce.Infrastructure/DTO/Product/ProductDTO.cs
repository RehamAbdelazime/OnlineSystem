using ECommerce.Domain.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.DTO.Product
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool HasAvailableStock { get; set; }
        public byte[] Image { get; set; }
        public int FK_CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
