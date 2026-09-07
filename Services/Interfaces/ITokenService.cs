using PersonalDigitalVaultSystem.Models;

namespace PersonalDigitalVaultSystem.Services.Interfaces
{
    public interface ITokenService
    {
        (string token, DateTime expiresAt) GenerateToken(ApplicationUser user);
    }
}
