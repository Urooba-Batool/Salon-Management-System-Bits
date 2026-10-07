using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.ResponseModels
{
    public class SalonServiceResponse
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public double ServicePrice { get; set; }
        public string ServiceTypeName { get; set; } = string.Empty; // Foreign key to ServiceType
        public Status ServiceStatus { get; set; } = Status.Active;
        public string CategoryName { get; set; } = string.Empty;
    }
}
