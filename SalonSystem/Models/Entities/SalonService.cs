using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.Entities
{
    public class SalonService
    {
        [Key]
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public double ServicePrice { get; set; }
        public int ServiceTypeId { get; set; } // Foreign key to ServiceType
        public Status ServiceStatus { get; set; } = Status.Active;
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;


        //foreign key navigation properties
        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }

        [ForeignKey(nameof(ServiceTypeId))]
        public ServiceType? ServiceType { get; set; }
    }
}
