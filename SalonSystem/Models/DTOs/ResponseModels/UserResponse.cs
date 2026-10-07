using SalonSystem.Constant;
using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.ResponseModels
{
    public class UserResponse
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserPhone { get; set; } = string.Empty;
        public UserType UserTypes { get; set; } = UserType.Customer;
        public Status UserStatus { get; set; } = Status.Active;
    }
}
