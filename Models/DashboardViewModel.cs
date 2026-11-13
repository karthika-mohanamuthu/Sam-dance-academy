
namespace DanceAcademy.Models
{
    public class DashboardViewModel
    {
        public int TotalEnquiries { get; set; }

        public List<EnquiryListViewModel> RecentEnquiries { get; set; }
            = new List<EnquiryListViewModel>();
    }
}
