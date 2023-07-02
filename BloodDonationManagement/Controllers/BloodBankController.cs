using BloodDonationManagement.Interfaces;
using BloodDonationManagement.Models;
using BloodDonationManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace BloodDonationManagement.Controllers
{
    public class BloodBankController : Controller
    {
        private readonly IBloodBankRepository _bloodBankRepository;

        public BloodBankController(IBloodBankRepository repository)
        {
            _bloodBankRepository = repository;
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
            _bloodBankRepository.Add(bloodBank);
            return RedirectToAction("Index");
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
				editBloodBank.Login = bloodBank.Login;
				editBloodBank.Password = bloodBank.Password;
				editBloodBank.AddressId = bloodBank.AddressId;
				editBloodBank.Address = bloodBank.Address;
				editBloodBank.BloodInventoryId = bloodBank.BloodInventoryId;
				editBloodBank.BloodInventory = bloodBank.BloodInventory;

				_bloodBankRepository.Update(editBloodBank);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// GET: BloodBank/Create = Create new Blood Bank
		//public IActionResult Create()
		//{
		//    ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id");
		//    ViewData["BloodInventoryId"] = new SelectList(_context.BloodInventories, "Id", "Id");
		//    return View();
		//}

		//// POST: BloodBank/Create
		//// To protect from overposting attacks, enable the specific properties you want to bind to.
		//// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Create([Bind("Id,Login,Name,Email,Password,AddressId,Telephone,BloodInventoryId")] BloodBank bloodBank)
		//{
		//    if (ModelState.IsValid)
		//    {
		//        _context.Add(bloodBank);
		//        await _context.SaveChangesAsync();
		//        return RedirectToAction(nameof(Index));
		//    }
		//    ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", bloodBank.AddressId);
		//    ViewData["BloodInventoryId"] = new SelectList(_context.BloodInventories, "Id", "Id", bloodBank.BloodInventoryId);
		//    return View(bloodBank);
		//}

		//// GET: BloodBank/Edit/5
		//public async Task<IActionResult> Edit(int? id)
		//{
		//    if (id == null || _context.BloodBanks == null)
		//    {
		//        return NotFound();
		//    }

		//    var bloodBank = await _context.BloodBanks.FindAsync(id);
		//    if (bloodBank == null)
		//    {
		//        return NotFound();
		//    }
		//    ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", bloodBank.AddressId);
		//    ViewData["BloodInventoryId"] = new SelectList(_context.BloodInventories, "Id", "Id", bloodBank.BloodInventoryId);
		//    return View(bloodBank);
		//}

		//// POST: BloodBank/Edit/5
		//// To protect from overposting attacks, enable the specific properties you want to bind to.
		//// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Edit(int id, [Bind("Id,Login,Name,Email,Password,AddressId,Telephone,BloodInventoryId")] BloodBank bloodBank)
		//{
		//    if (id != bloodBank.Id)
		//    {
		//        return NotFound();
		//    }

		//    if (ModelState.IsValid)
		//    {
		//        try
		//        {
		//            _context.Update(bloodBank);
		//            await _context.SaveChangesAsync();
		//        }
		//        catch (DbUpdateConcurrencyException)
		//        {
		//            if (!BloodBankExists(bloodBank.Id))
		//            {
		//                return NotFound();
		//            }
		//            else
		//            {
		//                throw;
		//            }
		//        }
		//        return RedirectToAction(nameof(Index));
		//    }
		//    ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", bloodBank.AddressId);
		//    ViewData["BloodInventoryId"] = new SelectList(_context.BloodInventories, "Id", "Id", bloodBank.BloodInventoryId);
		//    return View(bloodBank);
		//}

		//// GET: BloodBank/Delete/5
		//public async Task<IActionResult> Delete(int? id)
		//{
		//    if (id == null || _context.BloodBanks == null)
		//    {
		//        return NotFound();
		//    }

		//    var bloodBank = await _context.BloodBanks
		//        .Include(b => b.Address)
		//        .Include(b => b.BloodInventory)
		//        .FirstOrDefaultAsync(m => m.Id == id);
		//    if (bloodBank == null)
		//    {
		//        return NotFound();
		//    }

		//    return View(bloodBank);
		//}

		//// POST: BloodBank/Delete/5
		//[HttpPost, ActionName("Delete")]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> DeleteConfirmed(int id)
		//{
		//    if (_context.BloodBanks == null)
		//    {
		//        return Problem("Entity set 'DBContext.BloodBanks'  is null.");
		//    }
		//    var bloodBank = await _context.BloodBanks.FindAsync(id);
		//    if (bloodBank != null)
		//    {
		//        _context.BloodBanks.Remove(bloodBank);
		//    }

		//    await _context.SaveChangesAsync();
		//    return RedirectToAction(nameof(Index));
		//}

		//private bool BloodBankExists(int id)
		//{
		//    return (_context.BloodBanks?.Any(e => e.Id == id)).GetValueOrDefault();
		//}
	}
}
