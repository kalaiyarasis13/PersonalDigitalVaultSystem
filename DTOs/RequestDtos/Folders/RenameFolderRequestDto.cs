using System.ComponentModel.DataAnnotations;

namespace PersonalDigitalVaultSystem.DTOs.RequestDtos.Folders
{
    public class RenameFolderRequestDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
