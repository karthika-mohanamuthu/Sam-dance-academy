
using System.Diagnostics;
using DanceAcademy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DanceAcademy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(
     ILogger<HomeController> logger,
     AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
            [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
            public async Task<IActionResult> Dashboard()
            {
                var dashboard = new DashboardViewModel
                {
                    TotalEnquiries = await _context.Enquiries.CountAsync(),

                    RecentEnquiries = await _context.Enquiries
                        .OrderByDescending(e => e.Id)
                        .Take(5)
                        .Select(e => new EnquiryListViewModel
                        {
                            Id = e.Id,
                            FullName = e.FullName,
                            PhoneNumber = e.PhoneNumber,
                            Email = e.Email,
                            DanceStyle = e.DanceStyle,
                            Message = e.Message,
                            SubmittedAt = e.SubmittedAt,
                            Status = e.Status
                        })
                        .ToListAsync()
                };

                return View(dashboard);
            }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Styles()
        {
            return View();
        }

        public IActionResult Classes()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View();
        }

        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public async Task<IActionResult> Enquiries()
        {
            var enquiries = await _context.Enquiries
                .OrderByDescending(e => e.Id)
                .Select(e => new EnquiryListViewModel
                {
                    Id = e.Id,
                    FullName = e.FullName,
                    PhoneNumber = e.PhoneNumber,
                    Email = e.Email,
                    DanceStyle = e.DanceStyle,
                    Message = e.Message,
                    SubmittedAt = e.SubmittedAt,
                    Status = e.Status
                })
                .ToListAsync();

            return View(enquiries);
        }

        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public async Task<IActionResult> Students()
        {
            var students = await _context.Students
                .OrderByDescending(s => s.Id)
                .ToListAsync();

            return View(students);
        }


        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEnquiryStatus(int id, string status)
        {
            var allowedStatuses = new[] { "New", "Contacted", "Enrolled" };

            if (!allowedStatuses.Contains(status))
                return BadRequest();

            var enquiry = await _context.Enquiries.FindAsync(id);

            if (enquiry == null)
                return NotFound();

            // Create a student record when the enquiry is enrolled
            if (status == "Enrolled")
            {
                // Check whether this enquiry already has a student record
                var studentExists = await _context.Students
                    .AnyAsync(s => s.EnquiryId == enquiry.Id);

                if (!studentExists)
                {
                    // Validate the details required for student registration
                    if (string.IsNullOrWhiteSpace(enquiry.FullName) ||
                        string.IsNullOrWhiteSpace(enquiry.PhoneNumber) ||
                        string.IsNullOrWhiteSpace(enquiry.Email) ||
                        string.IsNullOrWhiteSpace(enquiry.StudentName) ||
                        string.IsNullOrWhiteSpace(enquiry.DanceStyle))
                    {
                        TempData["ErrorMessage"] =
                            "Cannot enroll. Required parent and student details are missing.";

                        return RedirectToAction(nameof(Enquiries));
                    }

                    var student = new Student
                    {
                        EnquiryId = enquiry.Id,
                        ParentName = enquiry.FullName,
                        ParentPhone = enquiry.PhoneNumber,
                        ParentEmail = enquiry.Email,
                        StudentName = enquiry.StudentName,
                        DateOfBirth = enquiry.DateOfBirth,
                        Gender = enquiry.Gender,
                        DanceStyle = enquiry.DanceStyle,
                        PreferredClassTiming = enquiry.PreferredClassTiming,
                        EnrolledAt = DateTime.Now,
                        IsActive = true
                    };

                    _context.Students.Add(student);
                }
            }

            enquiry.Status = status;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Enquiries));
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(Enquiry enquiry)
        {
            if (!ModelState.IsValid)
            {
                return View(enquiry);
            }
            enquiry.SubmittedAt = DateTime.Now;

            _context.Enquiries.Add(enquiry);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] =
                "Thank you! Your enquiry has been submitted successfully.";

            return RedirectToAction(nameof(Contact));
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
