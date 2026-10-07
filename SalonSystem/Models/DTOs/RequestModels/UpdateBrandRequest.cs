using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class UpdateBrandRequest
    {
        public string? BrandName { get; set; } 
        public Status? BrandStatus { get; set; }
    }
}
