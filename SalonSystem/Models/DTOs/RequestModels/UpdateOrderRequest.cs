using SalonSystem.Constant;
using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class UpdateOrderRequest
    {
        public int? UserId { get; set; }  // UserId to link the order to a specific user (foreign key)
        public int? EmployeeId { get; set; }  // EmployeeId to link the order to a specific employee for which the order is booked (foreign key)
        public DateTime? BookedFor { get; set; }  // Date nd time for which the order is booked
        public OrderType? OrderType { get; set; } 
        public PaymentType? PaymentType { get; set; } 
        public Source? Source { get; set; } 
        public Status? OrderStatus { get; set; }
        public List<int>? OrderItems { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
