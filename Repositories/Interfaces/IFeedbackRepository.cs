using PersonalDigitalVaultSystem.Models;

namespace PersonalDigitalVaultSystem.Repositories.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<Feedback> AddAsync(Feedback feedback);
        Task<Feedback?> GetLatestForUserAsync(int userId);
        Task<List<Feedback>> GetAllWithUserAsync();
    }
}
