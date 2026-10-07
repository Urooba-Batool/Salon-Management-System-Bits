using System.ComponentModel.DataAnnotations;
using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.Entities
{
    public class ServiceType
    {
        [Key]
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; } = string.Empty;
        public Status ServiceTypeStatus { get; set; } = Status.Active;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
