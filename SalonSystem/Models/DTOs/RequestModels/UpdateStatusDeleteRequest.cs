using SalonSystem.Constant;
using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class UpdateStatusDeleteRequest
    {
        public string EntityName { get; set; } 
        public int EntityId { get; set; }
        public Status? EntityStatus { get; set; } = Status.Inactive;
    }
}
