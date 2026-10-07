using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.ResponseModels
{
    public class RolesResponse
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public Status RoleStatus { get; set; } = Status.Active;
    }
}
