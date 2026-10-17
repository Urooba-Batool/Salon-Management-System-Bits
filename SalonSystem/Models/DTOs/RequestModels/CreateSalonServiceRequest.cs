using System.ComponentModel.DataAnnotations;
using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class CreateSalonServiceRequest
    {
        [Required]
        public string ServiceName { get; set; } = string.Empty;
        [Required]
        [Range (0, double.MaxValue)]
        public double ServicePrice { get; set; }
        [Required]
        public int ServiceTypeId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Status ServiceStatus { get; set; } = Status.Active;
    }
}
