using System.ComponentModel.DataAnnotations;

namespace SalonSystem.Models.DTOs.RequestModels
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string LoginEmail { get; set; } = string.Empty;

        [Required]
        public string LoginPassword { get; set; } = string.Empty;
    }
}
