using static SalonSystem.Constant.Enums;
using System.ComponentModel.DataAnnotations;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class CreateBrandRequest
    {
        public string BrandName { get; set; } = string.Empty;
        public Status? BrandStatus { get; set; } = Status.Active;
    }
}
