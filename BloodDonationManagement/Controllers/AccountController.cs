using BloodDonationManagement.DataAcessLayer;
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
						return RedirectToAction("Index", "BloodBank");
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
	}
}
