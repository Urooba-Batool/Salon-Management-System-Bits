namespace SalonSystem.Models.DTOs.RequestModels
{
    public class CreateProductRequest
    {
        public string ProductName { get; set; } = string.Empty;
        public double ProductPrice { get; set; }
        public int BrandId { get; set; }  // BrandId to connect with the Brand entity (foreign key)
        public int InStockQuantity { get; set; }
        public int CategoryId { get; set; }
    }
}
