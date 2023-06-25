using Microsoft.AspNetCore.Mvc;

namespace BloodDonationManagement.Controllers
{
    public class LearnMoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
