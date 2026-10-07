using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.Entities
{
    public class Employee
    {

        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeEmail { get; set; } = string.Empty;
        public string EmployeePassword { get; set; } = string.Empty;
        public int UserId { get; set; }  // UserId to link additional employee detail to the user (foreign key)
        public int RoleId { get; set; }  // RoleId entity to define the employee's role in the system (foreign key)
        public string EmployeeCnic { get; set; } = string.Empty;
        public double EmployeeSalary { get; set; }
        public string EmployeeAddress { get; set; } = string.Empty;
        public Status EmployeeStatus { get; set; } = Status.Active;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Timestamp when the employee was hired
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        //foreign key navigation properties

        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
