using System.ComponentModel.DataAnnotations;
using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class UpdateProductRequest
    {
        public string? ProductName { get; set; }

        [Range (0, double.MaxValue)]
        public double? ProductPrice { get; set; }
        public int? BrandId { get; set; }  // BrandId to connect with the Brand entity (foreign key)
        public int? InStockQuantity { get; set; }
        public int? CategoryId { get; set; }
        public Status? ProductStatus { get; set; }
        public Calculate? ProductCalculate { get; set; }

        [Range(0, int.MaxValue)]
        public int? Quantity { get; set; }
    }
}
