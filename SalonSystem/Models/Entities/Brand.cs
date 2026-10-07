using SalonSystem.Constant;
using System.ComponentModel.DataAnnotations;
using static SalonSystem.Constant.Enums;

namespace SalonSystem.Models.Entities
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public Status BrandStatus { get; set; } = Status.Active;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
