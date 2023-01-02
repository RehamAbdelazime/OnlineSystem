using ECommerce.Domain.Entities.Category;
using ECommerce.Domain.Entities.Photos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities.Product
{
    public class Products
    {
        public int ID { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool HasAvailableStock { get; set; }
        public string? Image { get; set; }
        public int FK_CategoryId { get; set; }
        public virtual Categories? ProductCategory { get; set; }
        //public virtual ICollection<ProductPhotos> ProductPhotos { get; set; }
    }
}
