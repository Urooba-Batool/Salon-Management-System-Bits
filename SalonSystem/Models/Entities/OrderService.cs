using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonSystem.Models.Entities
{
    public class OrderService
    {
        [Key]
        public int OrderServiceId { get; set; }
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;



        //foreign key navigation properties
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }

        [ForeignKey(nameof(ServiceId))]
        public virtual SalonService Services { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        public virtual Employee CreatorEmployee { get; set; }

        [ForeignKey(nameof(UpdatedBy))]
        public virtual Employee UpdaterEmployee { get; set; }
    }
}
