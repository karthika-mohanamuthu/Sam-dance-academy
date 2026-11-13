
using System.ComponentModel.DataAnnotations;

namespace DanceAcademy.Models
{
    public class Enquiry
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your phone number.")]
        [Phone(ErrorMessage = "Enter a valid phone number.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a dance style.")]
        public string DanceStyle { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Message { get; set; }


        [StringLength(100)]
        [Required(ErrorMessage = "Please enter the student name.")]
        public string? StudentName { get; set; }

        [Required(ErrorMessage = "Please select date of birth.")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please select gender.")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Please select preferred class timing.")]
        public string? PreferredClassTiming { get; set; }

        public DateTime? SubmittedAt { get; set; }

        public string Status { get; set; } = "New";
    }
}