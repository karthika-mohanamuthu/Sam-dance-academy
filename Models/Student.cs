
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DanceAcademy.Models
{
    [Index(nameof(EnquiryId), IsUnique = true)]
    public class Student
    {
        public int Id { get; set; }

        public int EnquiryId { get; set; }

        [Required]
        public string ParentName { get; set; } = string.Empty;

        [Required]
        public string ParentPhone { get; set; } = string.Empty;

        [Required]
        public string ParentEmail { get; set; } = string.Empty;

        [Required]
        public string StudentName { get; set; } = string.Empty;

        public DateTime? DateOfBirth { get; set; }

        public string? Gender { get; set; }

        [Required]
        public string DanceStyle { get; set; } = string.Empty;

        public string? PreferredClassTiming { get; set; }

        public DateTime EnrolledAt { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}
