using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class CreateServiceTypeRequest
    {
        public string ServiceTypeName { get; set; } = string.Empty;
    }
}
