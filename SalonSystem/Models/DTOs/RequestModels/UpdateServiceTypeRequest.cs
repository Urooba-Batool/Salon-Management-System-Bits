using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class UpdateServiceTypeRequest
    {
        public string ServiceTypeName { get; set; } = string.Empty;
        public Status? ServiceTypeStatus { get; set; } = Status.Active;
    }
}
