using Microsoft.AspNetCore.Mvc;

namespace BloodDonationManagement.Controllers
{
    public class DashboardBloodBank : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
