using SalonSystem.Constant;
using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class UpdateUserRequest
    {
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public string? UserPhone { get; set; }
        public UserType? UserTypes { get; set; }
        public Status? UserStatus { get; set; } 
    }
}
