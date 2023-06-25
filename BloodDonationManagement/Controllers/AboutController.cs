using Microsoft.AspNetCore.Mvc;

namespace BloodDonationManagement.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public IActionResult Index()
        {
            return View();
        }
    }
}
