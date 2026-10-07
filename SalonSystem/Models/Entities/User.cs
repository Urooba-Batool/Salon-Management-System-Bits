using SalonSystem.Constant;
using System.ComponentModel.DataAnnotations;
using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserPhone { get; set; } = string.Empty;
        public UserType UserTypes { get; set; } = UserType.Customer;
        public Status UserStatus { get; set; } = Status.Active;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
