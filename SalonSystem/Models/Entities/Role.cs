using System.ComponentModel.DataAnnotations;
using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.Entities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public Status RoleStatus { get; set; } = Status.Active;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
