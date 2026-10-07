using SalonSystem.Constant;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }  // UserId to link the order to a specific user (foreign key)
        public int? EmployeeId { get; set; }  // EmployeeId to link the order to a specific employee for which the order is booked (foreign key)
        public DateTime BookedFor { get; set; } = DateTime.UtcNow; // Date nd time for which the order is booked
        public OrderType OrderType { get; set; } = OrderType.WalkIn;
        public DateTime BookedOn { get; set; } = DateTime.UtcNow;  // Timestamp when the order was booked
        public int BookedBy { get; set; }  // EmployeeId of the person who booked the order (foreign key)
        public PaymentType PaymentType { get; set; } = PaymentType.Cash;
        public double? TotalAmount { get; set; }
        public Source Source { get; set; } = Source.WordOfMouth;
        public Status OrderStatus { get; set; } = Status.Pending;
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; } = DateTime.UtcNow;


        //foreign key navigation properties
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee Employee { get; set; }

        [ForeignKey(nameof(BookedBy))]
        public virtual Employee EmployeeBooker { get; set; }

        [ForeignKey(nameof(UpdatedBy))]
        public virtual Employee EmployeeUpdater { get; set; }
    }
}
