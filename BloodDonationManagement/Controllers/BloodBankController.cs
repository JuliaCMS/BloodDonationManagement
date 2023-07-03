﻿using BloodDonationManagement.Interfaces;
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
