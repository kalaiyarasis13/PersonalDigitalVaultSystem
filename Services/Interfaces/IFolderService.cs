using PersonalDigitalVaultSystem.DTOs.RequestDtos.Folders;
using PersonalDigitalVaultSystem.DTOs.ResponseDtos.Folders;

namespace PersonalDigitalVaultSystem.Services.Interfaces
{
    public interface IFolderService
    {
        Task<List<FolderResponseDto>> GetAllAsync(int userId);
        Task<FolderResponseDto> CreateAsync(int userId, CreateFolderRequestDto dto);
        Task<FolderResponseDto> RenameAsync(int userId, int folderId, RenameFolderRequestDto dto);
        Task DeleteAsync(int userId, int folderId);
    }
}
