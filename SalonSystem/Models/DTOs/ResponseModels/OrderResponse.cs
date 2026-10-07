using SalonSystem.Constant;
using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.ResponseModels
{
    public class OrderResponse
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }  // UserId to link the order to a specific user (foreign key)
        public string? EmployeeName { get; set; }  // EmployeeId to link the order to a specific employee for which the order is booked (foreign key)
        public DateTime BookedFor { get; set; } // Date nd time for which the order is booked
        public OrderType OrderType { get; set; } 

        public DateTime BookedOn { get; set; }   // Timestamp when the order was booked
        public string BookedByEmployee { get; set; }  // EmployeeId of the person who booked the order (foreign key)
        public PaymentType PaymentType { get; set; } 
        public double TotalAmount { get; set; }
        public Source Source { get; set; } 
        public Status OrderStatus { get; set; } 
        public string OrderItems { get; set; }
    }
}
