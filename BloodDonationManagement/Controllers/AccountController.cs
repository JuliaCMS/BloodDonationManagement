﻿using BloodDonationManagement.DataAcessLayer;
using BloodDonationManagement.Models;
using BloodDonationManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationManagement.Controllers
{
	public class AccountController : Controller
	{
		private readonly DBContext _context;

		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, DBContext context)
        {
            _context = context;
			_signInManager = signInManager;
			_userManager = userManager;
        }

		[HttpGet]
        public IActionResult Login()
		{
			var response = new LoginViewModel();
			return View(response);
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(loginViewModel);
			}

			var user = await _userManager.FindByEmailAsync(loginViewModel.EmailAddress);

			if (user != null)
			{
				// User is found, now is going to check password
				var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
				if (passwordCheck)
				{
					// Password is correct, sign in
					var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
					if (result.Succeeded)
					{
                        // Check the user role and redirect accordingly
                        if (User.IsInRole(UserRoles.Admin))
                        {
                            return RedirectToAction("Admin", "Dashboard");
                        }
                        else if (User.IsInRole(UserRoles.User))
                        {
                            return RedirectToAction("BloodBank", "Dashboard");
                        }
                        //return RedirectToAction("Index", "BloodBank");
                    }
				}
				// Password is incorrect
				TempData["Error"] = "Wrong password! Please try again.";
				return View(loginViewModel);
			}
			// User not found
			TempData["Error"] = "Wrong e-mail! Please try again.";
			return View(loginViewModel);
		}

        [HttpGet]
        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(registerViewModel);
			}

			var user = await _userManager.FindByEmailAsync(registerViewModel.EmailAddress);
			if(user != null) 
			{
				TempData["Error"] = "This e-mail address is already in use";
				return View(registerViewModel);
			}

			var newUser = new AppUser()
			{
				Email = registerViewModel.EmailAddress,
				UserName = registerViewModel.EmailAddress
			};
			var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);

			if (newUserResponse.Succeeded)
			{
				await _userManager.AddToRoleAsync(newUser, UserRoles.User);
			}
			TempData["SuccessMessage"] = "User successfully registered! Proceed to login";
			return RedirectToAction(nameof(Register));
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
    }
}
