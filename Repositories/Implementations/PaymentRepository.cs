using Microsoft.EntityFrameworkCore;
using PersonalDigitalVaultSystem.Data;
using PersonalDigitalVaultSystem.Models;
using PersonalDigitalVaultSystem.Repositories.Interfaces;

namespace PersonalDigitalVaultSystem.Repositories.Implementations
{
    public class PaymentRepository: IPaymentRepository
    {
        private readonly AddDbContext _context;
        public PaymentRepository(AddDbContext context) => _context = context;

        public async Task<PaymentTransaction> AddAsync(PaymentTransaction transaction)
        {
            _context.PaymentTransactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public Task<List<PaymentTransaction>> GetAllForUserAsync(int userId) =>
            _context.PaymentTransactions
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

    }
}
