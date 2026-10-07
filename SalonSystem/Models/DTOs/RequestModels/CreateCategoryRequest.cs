using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class CreateCategoryRequest
    {
        public string CategoryName { get; set; } = string.Empty;
    }
}
