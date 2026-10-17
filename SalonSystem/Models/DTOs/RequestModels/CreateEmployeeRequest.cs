using static SalonSystem.Constant.Enums;
using System.ComponentModel.DataAnnotations;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class CreateEmployeeRequest
    {
        [Required]
        [EmailAddress]
        public  string EmployeeEmail { get; set; } = string.Empty;
        [Required]
        [StringLength (50, MinimumLength = 5)]
        public  string EmployeePassword { get; set; } = string.Empty;
        [Required]
        public int UserId { get; set; }  // UserId to link additional employee detail to the user (foreign key)
        [Required]
        public int RoleId { get; set; }  // RoleId entity to define the employee's role in the system (foreign key)
        [Required]
        public string EmployeeCnic { get; set; } = string.Empty;
        [Required]
        [Range(0, double.MaxValue)]
        public double EmployeeSalary { get; set; }
        [Required]
        public string EmployeeAddress { get; set; } = string.Empty;
        public Status EmployeeStatus { get; set; } = Status.Active;  // Default status is Active
    }
}
