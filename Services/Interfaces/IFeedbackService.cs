using PersonalDigitalVaultSystem.DTOs.RequestDtos.Feedback;
using PersonalDigitalVaultSystem.DTOs.ResponseDtos.Feedback;

namespace PersonalDigitalVaultSystem.Services.Interfaces
{
    public interface IFeedbackService
    {
        Task<FeedbackResponseDto> SubmitAsync(int userId, SubmitFeedbackRequestDto dto);
        Task<FeedbackResponseDto?> GetMyLatestAsync(int userId);
        Task<List<AdminFeedbackListItemResponseDto>> GetAllForAdminAsync();
    }
}
