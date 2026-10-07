using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.ResponseModels
{
    public class EmployeeResponse
    {
        public int EmployeeId { get; set; } 
        public string EmployeeName { get; set; } = string.Empty;
        public string UserPhone { get; set; } = string.Empty;
        public string EmployeeEmail { get; set; } = string.Empty;
        public int UserId { get; set; }  // UserId to link additional employee detail to the user (foreign key)
        public string RoleName { get; set; }  // RoleId entity to define the employee's role in the system (foreign key)
        public string EmployeeCnic { get; set; } = string.Empty;
        public double EmployeeSalary { get; set; }
        public string EmployeeAddress { get; set; } = string.Empty;
        public Status EmployeeStatus { get; set; } = Status.Active;
    }
}
