using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class UpdateCategoryRequest
    {
        public string? CategoryName { get; set; }
        public Status? CategoryStatus { get; set; }
    }
}
