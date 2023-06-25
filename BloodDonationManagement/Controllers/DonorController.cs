using Microsoft.AspNetCore.Mvc;

namespace BloodDonationManagement.Controllers
{
    public class DonorController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
