using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class UpdateProductRequest
    {
        public string? ProductName { get; set; } 
        public double? ProductPrice { get; set; }
        public int? BrandId { get; set; }  // BrandId to connect with the Brand entity (foreign key)
        public int? InStockQuantity { get; set; }
        public int? CategoryId { get; set; }
        public Status? ProductStatus { get; set; }
        public Calculate? ProductCalculate { get; set; }
        public int? Quantity { get; set; }
    }
}
