using static SalonSystem.Constant.Enums;
using System.ComponentModel.DataAnnotations;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class CreateEmployeeRequest
    {
        
        public  string EmployeeEmail { get; set; } = string.Empty;
        public  string EmployeePassword { get; set; } = string.Empty;
        public int UserId { get; set; }  // UserId to link additional employee detail to the user (foreign key)
        public int RoleId { get; set; }  // RoleId entity to define the employee's role in the system (foreign key)
        public string EmployeeCnic { get; set; } = string.Empty;
        public double EmployeeSalary { get; set; }
        public string EmployeeAddress { get; set; } = string.Empty;
        public Status EmployeeStatus { get; set; } = Status.Active;  // Default status is Active
    }
}
