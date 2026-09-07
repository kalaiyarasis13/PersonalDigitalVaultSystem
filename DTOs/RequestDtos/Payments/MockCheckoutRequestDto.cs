using System.ComponentModel.DataAnnotations;

namespace PersonalDigitalVaultSystem.DTOs.RequestDtos.Payments
{
    public class MockCheckoutRequestDto
    {
        [Required]
        public string PlanName { get; set; } = "Premium";

        
        public string? FakeCardNumber { get; set; }
        public string? FakeCardExpiry { get; set; }
    }
}
