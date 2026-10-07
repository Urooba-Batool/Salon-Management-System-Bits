using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.ResponseModels
{
    public class ServiceTypeResponse
    {
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; } = string.Empty;
        public Status ServiceTypeStatus { get; set; } = Status.Active;
    }
}
