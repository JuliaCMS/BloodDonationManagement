using Microsoft.AspNetCore.Mvc;

namespace BloodDonationManagement.Controllers
{
    public class Dashboard : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult BloodBank()
        {
            return View();
        }
    }
}
