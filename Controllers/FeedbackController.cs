using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalDigitalVaultSystem.DTOs.RequestDtos.Feedback;
using PersonalDigitalVaultSystem.DTOs.ResponseDtos.Feedback;
using PersonalDigitalVaultSystem.Services.Implementations;
using PersonalDigitalVaultSystem.Services.Interfaces;
using System.Security.Claims;

namespace PersonalDigitalVaultSystem.Controllers
{
    /// <summary>Post-checkout customer feedback. Not part of the original BRD; added on request.</summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackSerivce;

        public FeedbackController(IFeedbackService feedbackSerivce) => _feedbackSerivce = feedbackSerivce;

        private int CurrentUserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        [HttpPost]
        public async Task<ActionResult<ApiResponseDto<FeedbackResponseDto>>> Submit(SubmitFeedbackRequestDto dto)
        {
            var result = await _feedbackSerivce.SubmitAsync(CurrentUserId, dto);
            return Ok(ApiResponseDto<FeedbackResponseDto>.Ok(result, "Thanks for your feedback!"));
        }
        [HttpGet("mine")]
        public async Task<ActionResult<ApiResponseDto<FeedbackResponseDto?>>> GetMine()
        {
            var result = await _feedbackSerivce.GetMyLatestAsync(CurrentUserId);
            return Ok(ApiResponseDto<FeedbackResponseDto?>.Ok(result));
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<ActionResult<ApiResponseDto<List<AdminFeedbackListItemResponseDto>>>> GetAll()
        {
            var result = await _feedbackSerivce.GetAllForAdminAsync();
            return Ok(ApiResponseDto<List<AdminFeedbackListItemResponseDto>>.Ok(result));
        }

    }
}
