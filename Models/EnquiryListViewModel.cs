
namespace DanceAcademy.Models
{
    public class EnquiryListViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string DanceStyle { get; set; } = string.Empty;
        public string? Message { get; set; }
        public DateTime? SubmittedAt { get; set; }

        public string Status { get; set; } = "New";
    }
}
