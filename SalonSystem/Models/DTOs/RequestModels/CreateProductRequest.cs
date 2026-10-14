using System;
using System.ComponentModel.DataAnnotations;
using SalonSystem.Constant;
using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class CreateProductRequest
    {
        [Required]
        public string ProductName { get; set; } = string.Empty;
        [Range(0,int.MaxValue)]
        public double ProductPrice { get; set; }
        public int BrandId { get; set; }  // BrandId to connect with the Brand entity (foreign key)

        public int InStockQuantity { get; set; }
        public int CategoryId { get; set; }
        public Status ProductStatus { get; set; } = Status.Active;
    }
}
