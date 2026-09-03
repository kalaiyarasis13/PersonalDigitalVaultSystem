using PersonalDigitalVaultSystem.DTOs.RequestDtos.Payments;
using PersonalDigitalVaultSystem.DTOs.ResponseDtos.Payments;
using PersonalDigitalVaultSystem.Models;
using PersonalDigitalVaultSystem.Repositories.Interfaces;
using PersonalDigitalVaultSystem.Services.Interfaces;

namespace PersonalDigitalVaultSystem.Services.Implementations;

public class PaymentService : IPaymentService
{
    private const long FreePlanBytes = 200L * 1024 * 1024;      // 200 MB
    private const long PremiumPlanBytes = 5L * 1024 * 1024 * 1024; // 5 GB

    private readonly IPaymentRepository _paymentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IDocumentRepository _documentRepository;

    public PaymentService(
        IPaymentRepository paymentRepository,
        IUserRepository userRepository,
        IDocumentRepository documentRepository)
    {
        _paymentRepository = paymentRepository;
        _userRepository = userRepository;
        _documentRepository = documentRepository;
    }

    public async Task<PaymentResponseDtos> MockCheckoutAsync(int userId, MockCheckoutRequestDto dto)
    {
        var user = await _userRepository.GetByIdAsync(userId)
            ?? throw new KeyNotFoundException("User not found.");

        // Always "succeeds" - this is a mock gateway, there is nothing to actually decline.
        var transaction = new PaymentTransaction
        {
            UserId = userId,
            PlanName = dto.PlanName,
            AmountCents = 499,
            Currency = "USD",
            Status = PaymentStatus.Success,
            MockGatewayReference = $"TXN-{Guid.NewGuid():N}".ToUpperInvariant()[..19],
            CreatedAt = DateTime.UtcNow
        };
        await _paymentRepository.AddAsync(transaction);

        user.Plan = StoragePlan.Premium;
        await _userRepository.UpdateAsync(user);

        return new PaymentResponseDtos
        {
            Success = true,
            PlanName = transaction.PlanName,
            MockGatewayReference = transaction.MockGatewayReference,
            CurrentPlan = user.Plan.ToString()
        };
    }

    public async Task<BillingStatusResponseDto> GetBillingStatusAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId)
            ?? throw new KeyNotFoundException("User not found.");

        var usedBytes = await _documentRepository.SumSizeBytesForUserAsync(userId);

        return new BillingStatusResponseDto
        {
            CurrentPlan = user.Plan.ToString(),
            StorageUsedBytes = usedBytes,
            StorageLimitBytes = user.Plan == StoragePlan.Premium ? PremiumPlanBytes : FreePlanBytes
        };
    }

    public async Task<List<PaymentHistoryItemResponseDto>> GetHistoryAsync(int userId)
    {
        var transactions = await _paymentRepository.GetAllForUserAsync(userId);
        return transactions.Select(t => new PaymentHistoryItemResponseDto
        {
            Id = t.Id,
            PlanName = t.PlanName,
            AmountCents = t.AmountCents,
            Currency = t.Currency,
            Status = t.Status.ToString(),
            MockGatewayReference = t.MockGatewayReference,
            CreatedAt = t.CreatedAt
        }).ToList();
    }
}


