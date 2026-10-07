namespace SalonSystem.Models.DTOs.RequestModels
{
    public class CreateOrderServiceRequest
    {
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
        public int CreatedBy { get; set; }
    }
}
