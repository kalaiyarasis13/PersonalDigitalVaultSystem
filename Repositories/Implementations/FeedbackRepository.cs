using Microsoft.EntityFrameworkCore;
using PersonalDigitalVaultSystem.Data;
using PersonalDigitalVaultSystem.Models;
using PersonalDigitalVaultSystem.Repositories.Interfaces;

namespace PersonalDigitalVaultSystem.Repositories.Implementations
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AddDbContext _context;

        public FeedbackRepository(AddDbContext context)
        {
            _context = context; 
        }
        public async Task<Feedback> CreateAsync(Feedback feedback) 
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }
       public Task<Feedback?> GetLatestForUserAsync(int userId) =>
        _context.Feedbacks
            .Where(f => f.UserId == userId)
            .OrderByDescending(f => f.CreatedAt)
            .FirstOrDefaultAsync();

        public Task<List<Feedback>> GetAllWithUserAsync() =>
            _context.Feedbacks
                .Include(f => f.User)
                .OrderByDescending(f => f.CreatedAt)
                .ToListAsync();

    }
}
