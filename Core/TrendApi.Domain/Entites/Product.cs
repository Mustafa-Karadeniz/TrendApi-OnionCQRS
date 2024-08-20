using TrendApi.Domain.Common;

namespace TrendApi.Domain.Entites
{
    public class Product:EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public Brand Brands { get; set; }

        public ICollection<Category> Categories { get; set; }
        
        //public required string ImagePath { get; set; }
    }
}
