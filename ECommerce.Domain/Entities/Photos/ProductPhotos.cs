using ECommerce.Domain.Entities.Category;
using ECommerce.Domain.Entities.Product;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain.Entities.Photos
{
    public class ProductPhotos
    {
        public int ID { get; set; }
        public byte[] ImageBytes { get; set; }
        public string Description { get; set; }
        public string FileExtension { get; set; }
        public decimal Size { get; set; }
        public int ProductId { get; set; }
        public int FK_ProductId { get; set; }
        public Products ProductPhoto { get; set; }
    }
}
