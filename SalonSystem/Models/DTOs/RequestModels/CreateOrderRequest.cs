using SalonSystem.Constant;
using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class CreateOrderRequest
    {
        public int UserId { get; set; }  // UserId to link the order to a specific user (foreign key)
        public int? EmployeeId { get; set; }  // EmployeeId to link the order to a specific employee for which the order is booked (foreign key)
        public DateTime BookedFor { get; set; } = DateTime.UtcNow; // Date nd time for which the order is booked
        public OrderType OrderTypes { get; set; } = OrderType.WalkIn;
        public DateTime BookedOn { get; set; } = DateTime.UtcNow;  // Timestamp when the order was booked
        public int BookedBy { get; set; }  // EmployeeId of the person who booked the order (foreign key)
        public PaymentType PaymentTypes { get; set; } = PaymentType.Cash;
        public double? TotalAmount { get; set; }
        public Source Sources { get; set; } = Source.WordOfMouth;
        public List<int> ServiceId { get; set; }
        public int CreatedBy { get; set; }
    }
}
