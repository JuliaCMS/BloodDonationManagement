﻿using BloodDonationManagement.Models;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace BloodDonationManagement.DataAcessLayer
{
	public class Seed
	{
		public static void SeedData(IApplicationBuilder applicationBuilder)
		{
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<DBContext>();

				context.Database.EnsureCreated();

				if (!context.BloodBanks.Any())
				{
					context.BloodBanks.AddRange(new List<BloodBank>()
					{
						new BloodBank()
						{
							Login = "banco1",
							Name = "Hospital de Sangue",
							Email = "contato@hospitalsangue.com.br",
							Password = "sangue123",
							Address = new Address()
							{
								Street = "Avenida Nova 5580",
								City = "São Paulo",
								State = "SP"
							},
							Telephone = "",
							BloodInventory = new BloodInventory()
							{
								Components = new List<BloodType>()
								{
									new BloodType()
									{
										BloodComponentType = "Red Blood Cell Concentrate",
										AboRhType = "O+",
										Quantity = 42
									},
									new BloodType()
									{
										BloodComponentType = "Platelets",
										AboRhType = "O+",
										Quantity = 7
									},
									new BloodType()
									{
										BloodComponentType = "Fresh Frozen Plasma",
										AboRhType = "O+",
										Quantity = 45
									},
									new BloodType()
									{
										BloodComponentType = "Cryoprecipitate",
										AboRhType = "O+",
										Quantity = 15
									}
								}
							}
						 },
						new BloodBank()
						{
							Login = "banco2",
							Name = "Hemoclínica",
							Email = "contato@hemoclinica.com.br",
							Password = "senha789",
							Address = new Address()
							{
								Street = "Rua Camila 1356",
								City = "Belo Horizonte",
								State = "MG"
							 },
							Telephone = "(31) 6543-2109",
							BloodInventory = new BloodInventory()
							{
								Components = new List<BloodType>()
								{
									new BloodType()
									{
										BloodComponentType = "Red Blood Cell Concentrate",
										AboRhType = "O+",
										Quantity = 48
									},
									new BloodType()
									{
										BloodComponentType = "Platelets",
										AboRhType = "O+",
										Quantity = 15
									},
									new BloodType()
									{
										BloodComponentType = "Fresh Frozen Plasma",
										AboRhType = "O+",
										Quantity = 17
									},
									new BloodType()
									{
										BloodComponentType = "Cryoprecipitate",
										AboRhType = "O+",
										Quantity = 25
									}
								}
							}
						},
						new BloodBank()
						{
							Login = "banco3",
							Name = "Sangue Vida",
							Email = "contato@sanguevida.com.br",
							Password = "senha654",
							Address = new Address()
							{
								Street = "Rua Nossa Senhora 164",
								City = "São Paulo",
								State = "SP"
							 },
							Telephone = "(11) 2266-3145",
							BloodInventory = new BloodInventory()
							{
								Components = new List<BloodType>()
								{
									new BloodType()
									{
										BloodComponentType = "Red Blood Cell Concentrate",
										AboRhType = "O-",
										Quantity = 10
									},
									new BloodType()
									{
										BloodComponentType = "Platelets",
										AboRhType = "O+",
										Quantity = 12
									},
									new BloodType()
									{
										BloodComponentType = "Fresh Frozen Plasma",
										AboRhType = "O+",
										Quantity = 18
									},
									new BloodType()
									{
										BloodComponentType = "Cryoprecipitate",
										AboRhType = "AB-",
										Quantity = 15
									}
								}
							}
						},
						new BloodBank()
						{
							Login = "banco4",
							Name = "Banco de Sangue São Lucas",
							Email = "contato@sangue-saolucas.com.br",
							Password = "senha756",
							Address = new Address()
							{
								Street = "Rua da Saúde 769",
								City = "Londrina",
								State = "PR"
							 },
							Telephone = "(43) 5626-8925",
							BloodInventory = new BloodInventory()
							{
								Components = new List<BloodType>()
								{
									new BloodType()
									{
										BloodComponentType = "Red Blood Cell Concentrate",
										AboRhType = "O+",
										Quantity = 46
									},
									new BloodType()
									{
										BloodComponentType = "Platelets",
										AboRhType = "A+",
										Quantity = 5
									},
									new BloodType()
									{
										BloodComponentType = "Fresh Frozen Plasma",
										AboRhType = "O-",
										Quantity = 45
									},
									new BloodType()
									{
										BloodComponentType = "Cryoprecipitate",
										AboRhType = "AB+",
										Quantity = 48
									}
								}
							}
						}
					});
					context.SaveChanges();
				}
			}
		}

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
						Name = "Julia Mourão",
						Cpf = "123.456.789-12",
						Telephone = "(11)91234-5678",
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
						Name = "Banco de Sangue São Lucas",
						Cnpj = "12.132.456/0001-12",
						Telephone = "(11)1234-5678",
						Email = appUserEmail,
						EmailConfirmed = true,
						Address = new Address()
						{
							Street = "Rua da Saúde 769",
							City = "Londrina",
							State = "PR"
						},
						BloodInventory = new BloodInventory()
						{
							Components = new List<BloodType>()
							{
									new BloodType()
									{
										BloodComponentType = "Red Blood Cell Concentrate",
										AboRhType = "O+",
										Quantity = 46
									},
									new BloodType()
									{
										BloodComponentType = "Platelets",
										AboRhType = "A+",
										Quantity = 5
									},
									new BloodType()
									{
										BloodComponentType = "Fresh Frozen Plasma",
										AboRhType = "O-",
										Quantity = 45
									},
									new BloodType()
									{
										BloodComponentType = "Cryoprecipitate",
										AboRhType = "AB+",
										Quantity = 48
									}
							}
						}
					};
					await userManager.CreateAsync(newAppUser, "Coding@1234?");
					await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
				}
			}
		}
	}
}


