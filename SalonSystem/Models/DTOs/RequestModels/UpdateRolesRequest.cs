using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class UpdateRolesRequest
    {
        public string? RoleName { get; set; } 
        public Status? RoleStatus { get; set; }
    }
}
