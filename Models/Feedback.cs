namespace PersonalDigitalVaultSystem.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public ApplicationUser? User { get; set; }

        public int Rating { get; set; }

        public string? Comment { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
