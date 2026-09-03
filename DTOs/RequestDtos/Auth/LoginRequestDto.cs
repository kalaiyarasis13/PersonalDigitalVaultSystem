using System.ComponentModel.DataAnnotations;

namespace PersonalDigitalVaultSystem.DTOs.RequestDtos.Auth
{
    public class LoginRequestDto
    {
        [Required]
        public string UsernameOrEmail { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
