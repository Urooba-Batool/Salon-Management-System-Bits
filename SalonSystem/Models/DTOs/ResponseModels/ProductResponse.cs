using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.ResponseModels
{
    public class ProductResponse
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public double ProductPrice { get; set; }
        public string BrandName { get; set; }
        public int InStockQuantity { get; set; }
        public string CategoryName { get; set; }
        public Status ProductStatus { get; set; }
    }
}
