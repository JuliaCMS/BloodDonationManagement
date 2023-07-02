using BloodDonationManagement.Interfaces;
using BloodDonationManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodDonationManagement.Controllers
{
	public class DonorController : Controller
	{
		private readonly IDonorRepository _donorRepository;

		public DonorController(IDonorRepository repository)
		{
			_donorRepository = repository;
		}

		// GET: Donor/Index = All donors
		public async Task<IActionResult> Index()
		{
			IEnumerable<Donor> donors = await _donorRepository.GetAll();
			return View(donors);
		}

		// GET: Donor/Details/{1}
		public async Task<IActionResult> Details(int id)
		{
			Donor donor = await _donorRepository.GetByIdAsync(id);
			return View(donor);
		}

		// GET: Donor/Create = form
		public IActionResult Create()
		{
			return View();
		}

		// POST: Donor/Create = Create new Donor
		//[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<IActionResult> Create(Donor donor)
		{
			if (!ModelState.IsValid)
			{
				return View(donor);
			}
			_donorRepository.Add(donor);
			return RedirectToAction("Index");
		}

		// GET: Donor/Edit/{id}
		public async Task<IActionResult> Edit(int id)
		{
			var donor = await _donorRepository.GetByIdAsync(id);
			if (donor == null)
			{
				return NotFound();
			}
			return View(donor);
		}

		// POST: Donor/Edit/{id}
		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Donor donor)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var editDonor = await _donorRepository.GetByIdAsyncNoTracking(id);

			if (editDonor == null)
			{
				return NotFound("Donor not found!");
			}

			try
			{
				editDonor.Id = id;
				editDonor.FullName = donor.FullName;
				editDonor.DateOfBirth = donor.DateOfBirth;
				editDonor.Email = donor.Email;
				editDonor.Telephone = donor.Telephone;
				editDonor.BloodTypeId = donor.BloodTypeId;
				editDonor.BloodType = donor.BloodType;
				editDonor.LastDonation = donor.LastDonation;
				editDonor.AddressId = donor.AddressId;
				editDonor.Address = donor.Address;

				_donorRepository.Update(editDonor);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		//// GET: Donor/Delete/5
		//public async Task<IActionResult> Delete(int? id)
		//{
		//    if (id == null || _context.Donors == null)
		//    {
		//        return NotFound();
		//    }

		//    var donor = await _context.Donors
		//        .Include(d => d.Address)
		//        .Include(d => d.BloodType)
		//        .FirstOrDefaultAsync(m => m.Id == id);
		//    if (donor == null)
		//    {
		//        return NotFound();
		//    }

		//    return View(donor);
		//}

		//// POST: Donor/Delete/5
		//[HttpPost, ActionName("Delete")]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> DeleteConfirmed(int id)
		//{
		//    if (_context.Donors == null)
		//    {
		//        return Problem("Entity set 'DBContext.Donors'  is null.");
		//    }
		//    var donor = await _context.Donors.FindAsync(id);
		//    if (donor != null)
		//    {
		//        _context.Donors.Remove(donor);
		//    }

		//    await _context.SaveChangesAsync();
		//    return RedirectToAction(nameof(Index));
		//}

		//private bool DonorExists(int id)
		//{
		//  return (_context.Donors?.Any(e => e.Id == id)).GetValueOrDefault();
		//}
	}
}
