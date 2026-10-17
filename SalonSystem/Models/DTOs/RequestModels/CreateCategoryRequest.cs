using static SalonSystem.Constant.Enums;
using System.ComponentModel.DataAnnotations;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class CreateCategoryRequest
    {
        [Required]
        public string CategoryName { get; set; } = string.Empty;
        public Status? CategoryStatus { get; set; } = Status.Active;
    }
}
