using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BloodDonationManagement.DataAcessLayer;
using BloodDonationManagement.Models;

namespace BloodDonationManagement.Controllers
{
    public class BloodBankController : Controller
    {
        private readonly DBContext _context;

        public BloodBankController(DBContext context)
        {
            _context = context;
        }

        // GET: BloodBank
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.BloodBanks.Include(b => b.Address).Include(b => b.BloodInventory);
            return View(await dBContext.ToListAsync());
        }

        // GET: BloodBank/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BloodBanks == null)
            {
                return NotFound();
            }

            var bloodBank = await _context.BloodBanks
                .Include(b => b.Address)
                .Include(b => b.BloodInventory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloodBank == null)
            {
                return NotFound();
            }

            return View(bloodBank);
        }

        // GET: BloodBank/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id");
            ViewData["BloodInventoryId"] = new SelectList(_context.BloodInventories, "Id", "Id");
            return View();
        }

        // POST: BloodBank/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Login,Name,Email,Password,AddressId,Telephone,BloodInventoryId")] BloodBank bloodBank)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bloodBank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", bloodBank.AddressId);
            ViewData["BloodInventoryId"] = new SelectList(_context.BloodInventories, "Id", "Id", bloodBank.BloodInventoryId);
            return View(bloodBank);
        }

        // GET: BloodBank/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BloodBanks == null)
            {
                return NotFound();
            }

            var bloodBank = await _context.BloodBanks.FindAsync(id);
            if (bloodBank == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", bloodBank.AddressId);
            ViewData["BloodInventoryId"] = new SelectList(_context.BloodInventories, "Id", "Id", bloodBank.BloodInventoryId);
            return View(bloodBank);
        }

        // POST: BloodBank/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Login,Name,Email,Password,AddressId,Telephone,BloodInventoryId")] BloodBank bloodBank)
        {
            if (id != bloodBank.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bloodBank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BloodBankExists(bloodBank.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", bloodBank.AddressId);
            ViewData["BloodInventoryId"] = new SelectList(_context.BloodInventories, "Id", "Id", bloodBank.BloodInventoryId);
            return View(bloodBank);
        }

        // GET: BloodBank/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BloodBanks == null)
            {
                return NotFound();
            }

            var bloodBank = await _context.BloodBanks
                .Include(b => b.Address)
                .Include(b => b.BloodInventory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloodBank == null)
            {
                return NotFound();
            }

            return View(bloodBank);
        }

        // POST: BloodBank/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BloodBanks == null)
            {
                return Problem("Entity set 'DBContext.BloodBanks'  is null.");
            }
            var bloodBank = await _context.BloodBanks.FindAsync(id);
            if (bloodBank != null)
            {
                _context.BloodBanks.Remove(bloodBank);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BloodBankExists(int id)
        {
          return (_context.BloodBanks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
