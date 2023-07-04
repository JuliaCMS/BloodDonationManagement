using BloodDonationManagement.Models;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace BloodDonationManagement.DataAcessLayer
{
	public class Seed
	{
		public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
		{
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
				//Roles
				var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

				if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
					await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
				if (!await roleManager.RoleExistsAsync(UserRoles.User))
					await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

				//Users

				//Manager
				var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
				string adminUserEmail = "juli4.cms@gmail.com";

				var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
				if (adminUser == null)
				{
					var newAdminUser = new AppUser()
					{
						UserName = "juliacms",
						Email = adminUserEmail,
						EmailConfirmed = true,
						Address = new Address()
						{
							Street = "Rua Dias da Silva 868",
							City = "São Paulo",
							State = "SP"
						}
					};
					await userManager.CreateAsync(newAdminUser, "Coding@1234?");
					await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
				}

				// AppUsers
				string appUserEmail = "contato@sangue-saolucas.com.br";

				var appUser = await userManager.FindByEmailAsync(appUserEmail);
				if (appUser == null)
				{
					var newAppUser = new AppUser()
					{
						UserName = "bs1",
						Email = appUserEmail,
						EmailConfirmed = true,
						Address = new Address()
						{
							Street = "Rua da Saúde 769",
							City = "Londrina",
							State = "PR"
						},
					};
					await userManager.CreateAsync(newAppUser, "Coding@1234?");
					await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
				}
			}
		}
	}
}


