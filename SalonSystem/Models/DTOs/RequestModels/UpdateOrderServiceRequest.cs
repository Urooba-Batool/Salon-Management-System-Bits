namespace SalonSystem.Models.DTOs.RequestModels
{
    public class UpdateOrderServiceRequest
    {
        public int? OrderId { get; set; }
        public int? ServiceId { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
