using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class UpdateSalonServiceRequest
    {
        public string? ServiceName { get; set; }
        public double? ServicePrice { get; set; }
        public int? ServiceTypeId { get; set; } // Foreign key to ServiceType
        public Status? ServiceStatus { get; set; }
        public int? CategoryId { get; set; }
    }
}
