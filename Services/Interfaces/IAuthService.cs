using PersonalDigitalVaultSystem.DTOs.RequestDtos.Auth;
using PersonalDigitalVaultSystem.DTOs.ResponseDtos.Auth;

namespace PersonalDigitalVaultSystem.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto);
        Task<AuthResponseDto> LoginAsync(LoginRequestDto dto);
        Task<UserProfileResponseDto> GetProfileAsync(int userId);
        Task<UserProfileResponseDto> UpdateProfileAsync(int userId, UpdateProfileRequestDto dto);
        Task ChangePasswordAsync(int userId, ChangePasswordRequestDto dto);
    }
}
