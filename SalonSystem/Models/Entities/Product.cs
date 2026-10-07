using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public double ProductPrice { get; set; }
        public int BrandId { get; set; }  // BrandId to connect with the Brand entity (foreign key)
        public int InStockQuantity { get; set; }
        public int CategoryId { get; set; }  // CategoryId to connect with the Category entity (foreign key)
        public Status ProductStatus { get; set; } = Status.Active;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
        public Calculate? ProductCalculate { get; set; }  // Optional property to indicate how the product quantity should be calculated (add or subtract)


        //foreign key navigation properties
        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
    }
}
