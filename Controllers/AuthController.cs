using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalDigitalVaultSystem.DTOs.RequestDtos.Auth;
using PersonalDigitalVaultSystem.DTOs.ResponseDtos.Auth;
using PersonalDigitalVaultSystem.DTOs.ResponseDtos.Common;
using PersonalDigitalVaultSystem.Services.Interfaces;
using System.Security.Claims;

namespace PersonalDigitalVaultSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) => _authService = authService;

        private int CurrentUserId =>
            int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponseDto<AuthResponseDto>>> Register(RegisterRequestDto dto)
        {
            var result = await _authService.RegisterAsync(dto);
            return Ok(ApiResponseDto<AuthResponseDto>.Ok(result, "Account created successfully."));
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponseDto<AuthResponseDto>>> Login(LoginRequestDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            return Ok(ApiResponseDto<AuthResponseDto>.Ok(result, "Login successful."));
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<ActionResult<ApiResponseDto<UserProfileResponseDto>>> GetProfile()
        {
            var result = await _authService.GetProfileAsync(CurrentUserId);
            return Ok(ApiResponseDto<UserProfileResponseDto>.Ok(result));
        }

        [Authorize]
        [HttpPut("profile")]
        public async Task<ActionResult<ApiResponseDto<UserProfileResponseDto>>> UpdateProfile(UpdateProfileRequestDto dto)
        {
            var result = await _authService.UpdateProfileAsync(CurrentUserId, dto);
            return Ok(ApiResponseDto<UserProfileResponseDto>.Ok(result, "Profile updated."));
        }

        [Authorize]
        [HttpPut("change-password")]
        public async Task<ActionResult<ApiResponseDto<object>>> ChangePassword(ChangePasswordRequestDto dto)
        {
            await _authService.ChangePasswordAsync(CurrentUserId, dto);
            return Ok(ApiResponseDto<object>.Ok(new { }, "Password changed successfully."));
        }
    }
}
