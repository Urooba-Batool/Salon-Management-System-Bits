using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class CreateSalonServiceRequest
    {
        public string ServiceName { get; set; } = string.Empty;
        public double ServicePrice { get; set; }
        public int ServiceTypeId { get; set; } 
        public int CategoryId { get; set; }
    }
}
