using PersonalDigitalVaultSystem.DTOs.RequestDtos.Payments;
using PersonalDigitalVaultSystem.DTOs.ResponseDtos.Payments;

namespace PersonalDigitalVaultSystem.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResponseDtos> MockCheckoutAsync(int userId, MockCheckoutRequestDto dto);
        Task<BillingStatusResponseDto> GetBillingStatusAsync(int userId);
        Task<List<PaymentHistoryItemResponseDto>> GetHistoryAsync(int userId);
    }
}
