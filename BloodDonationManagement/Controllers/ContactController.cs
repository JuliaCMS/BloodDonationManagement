using BloodDonationManagement.DataAcessLayer;
using BloodDonationManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationManagement.Controllers
{
    public class ContactController : Controller
    {
        /*
        private readonly DbContext _context;

        public ContactController(DbContext context)
        {
           _context = context;
        }
        */

        // PUT: Contact
        public IActionResult Index()
        {
            return View();
        }
        /*
        // POST: Contato/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,RegisteredId,UserType,Subject,Message")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }
    }
        */

        /*
        // GET: Contact
        public ActionResult Index()
        {
            return View(_context.Contact.ToList());
        }
        */
    }
}

