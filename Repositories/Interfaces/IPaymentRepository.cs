using PersonalDigitalVaultSystem.Models;

namespace PersonalDigitalVaultSystem.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<PaymentTransaction> AddAsync(PaymentTransaction transaction);
        Task<List<PaymentTransaction>> GetAllForUserAsync(int userId);
    }

}

