using SalonSystem.Constant;
using System.ComponentModel.DataAnnotations;
using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class CreateUserRequest
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string UserPhone { get; set; } = string.Empty;
        public UserType UserTypes { get; set; } = UserType.Customer;
        public Status UserStatus { get; set; } = Status.Active;

    }
}
