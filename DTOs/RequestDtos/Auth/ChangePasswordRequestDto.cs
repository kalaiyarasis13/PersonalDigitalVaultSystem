using System.ComponentModel.DataAnnotations;

namespace PersonalDigitalVaultSystem.DTOs.RequestDtos.Auth
{
    public class ChangePasswordRequestDto
    {
        [Required]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required, MinLength(8)]
        public string NewPassword { get; set; } = string.Empty;
    }
}
