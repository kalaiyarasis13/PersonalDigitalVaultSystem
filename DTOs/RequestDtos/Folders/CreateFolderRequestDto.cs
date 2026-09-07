using System.ComponentModel.DataAnnotations;

namespace PersonalDigitalVaultSystem.DTOs.RequestDtos.Folders
{
    public class CreateFolderRequestDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public int? ParentFolderId { get; set; }
    }
}
