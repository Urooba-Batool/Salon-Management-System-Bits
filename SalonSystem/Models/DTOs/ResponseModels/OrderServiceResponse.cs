namespace SalonSystem.Models.DTOs.ResponseModels
{
    public class OrderServiceResponse
    {
        public int OrderServiceId { get; set; }
        public string? ServiceName { get; set; }
        public double ServicePrice { get; set; }
    }
}
