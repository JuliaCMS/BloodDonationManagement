using BloodDonationManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BloodDonationManagement.Controllers
{
    public class BloodInventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /*
        private readonly ApplicationDbContext _context;

        public BloodInventoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BloodInventory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodInventory bloodInventory = _context.BloodInventories.Find(id);
            if (bloodInventory == null)
            {
                return HttpNotFound();
            }
            return View(bloodInventory);
        }

        // GET: BloodInventory/AddBloodBag/5
        public ActionResult AddBloodBag(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodInventory bloodInventory = _context.BloodInventories.Find(id);
            if (bloodInventory == null)
            {
                return HttpNotFound();
            }
            bloodInventory.Quantity++;
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = id });
        }

        // GET: BloodInventory/RemoveBloodBag/5
        public ActionResult RemoveBloodBag(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodInventory bloodInventory = _context.BloodInventories.Find(id);
            if (bloodInventory == null)
            {
                return HttpNotFound();
            }
            if (bloodInventory.Quantity > 0)
            {
                bloodInventory.Quantity--;
                _context.SaveChanges();
            }
            return RedirectToAction("Details", new { id = id });
        }
        */
    }
}
