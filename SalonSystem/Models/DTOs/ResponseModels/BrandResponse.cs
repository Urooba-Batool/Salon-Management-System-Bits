using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.ResponseModels
{
    public class BrandResponse
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public Status BrandStatus { get; set; }
    }
}
