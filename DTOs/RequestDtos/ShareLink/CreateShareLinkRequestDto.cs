using System.ComponentModel.DataAnnotations;

namespace PersonalDigitalVaultSystem.DTOs.RequestDtos.ShareLink
{
    public class CreateShareLinkRequestDto
    {
        [Range(1, 24 * 30)] // 1 hour to 30 days
        public int ExpiryHours { get; set; } = 24;
    }
}

