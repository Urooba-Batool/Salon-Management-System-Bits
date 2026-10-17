using System.ComponentModel.DataAnnotations;
using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class UpdateEmployeeRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserPhone { get; set; }

        [EmailAddress]
        public string? EmployeeEmail { get; set; }

        [StringLength(50, MinimumLength = 5)]
        public string? EmployeePassword { get; set; }
        public int? UserId { get; set; }  // UserId to link additional employee detail to the user (foreign key)
        public int? RoleId { get; set; }  // RoleId entity to define the employee's role in the system (foreign key)
        public string? EmployeeCnic { get; set; }

        [Range(0, double.MaxValue)]
        public double? EmployeeSalary { get; set; }
        public string? EmployeeAddress { get; set; }
        public Status? EmployeeStatus { get; set; }
    }
}
