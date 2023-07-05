using BloodDonationManagement.Interfaces;
using BloodDonationManagement.Models;
using BloodDonationManagement.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace BloodDonationManagement.Controllers
{
    public class BloodBankController : Controller
    {
        private readonly IBloodBankRepository _bloodBankRepository;
        private readonly UserManager<AppUser> _userManager;

        public BloodBankController(IBloodBankRepository repository, UserManager<AppUser> userManager)
        {
            _bloodBankRepository = repository;
			_userManager = userManager;
        }

        // GET: BloodBank/Index = All Blood Banks
        public async Task<IActionResult> Index()
        {
            IEnumerable<BloodBank> bloodBanks = await _bloodBankRepository.GetAll();
            return View(bloodBanks);
        }

        // GET: BloodBank/Details/{1}
        public async Task<IActionResult> Details(int id)
        {
            BloodBank bloodBank = await _bloodBankRepository.GetByIdAsync(id);
            return View(bloodBank);
        }

        // GET: BloodBank/Create = form
        public IActionResult Create()
        {
            return View();
        }

        // POST: BloodBank/Create = Create new Blood Bank
        [HttpPost]
        public async Task<IActionResult> Create(BloodBank bloodBank)
        {
            if (!ModelState.IsValid)
            {
                return View(bloodBank);
            }
            var user = await _userManager.GetUserAsync(User);

            _bloodBankRepository.Add(bloodBank);

			TempData["SuccessMessage"] = "Blood Bank successfully registered!";
			return RedirectToAction(nameof(Create));
        }

		// GET: BloodBank/Edit/{id}
		public async Task<IActionResult> Edit(int id)
		{
			var donor = await _bloodBankRepository.GetByIdAsync(id);
			if (donor == null)
			{
				return NotFound();
			}
			return View(donor);
		}

		// POST: BloodBank/Edit/{id}
		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, BloodBank bloodBank)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var editBloodBank = await _bloodBankRepository.GetByIdAsyncNoTracking(id);
			if (editBloodBank == null)
			{
				return NotFound("Donor not found!");
			}

			try
			{
				editBloodBank.Id = id;
				editBloodBank.Name = bloodBank.Name;
				editBloodBank.Email = bloodBank.Email;
				editBloodBank.Telephone = bloodBank.Telephone;
				editBloodBank.AddressId = bloodBank.AddressId;
				editBloodBank.Address = bloodBank.Address;

				_bloodBankRepository.Update(editBloodBank);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// GET: BloodBank/Delete/{id}
		public async Task<IActionResult> Delete(int id)
		{
			var bloodBankDetails = await _bloodBankRepository.GetByIdAsync(id);
			if (bloodBankDetails == null)
			{
				return BadRequest("Error");
			}
			return View(bloodBankDetails);
		}

		// POST: BloodBank/Delete/{id}
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteBloodBank(int id)
		{
			var bloodBankDetails = await _bloodBankRepository.GetByIdAsync(id);
			if (bloodBankDetails == null)
			{
				return BadRequest("Error");
			}

			_bloodBankRepository.Delete(bloodBankDetails);
			return RedirectToAction("Index");
		}
	}
}
