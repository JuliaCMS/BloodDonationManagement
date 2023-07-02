using BloodDonationManagement.Models;

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

                /*
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
                        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                        string adminUserEmail = "teddysmithdeveloper@gmail.com";

                        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                        if (adminUser == null)
                        {
                            var newAdminUser = new AppUser()
                            {
                                UserName = "teddysmithdev",
                                Email = adminUserEmail,
                                EmailConfirmed = true,
                                Address = new Address()
                                {
                                    Street = "123 Main St",
                                    City = "Charlotte",
                                    State = "NC"
                                }
                            };
                            await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                        }

                        string appUserEmail = "user@etickets.com";

                        var appUser = await userManager.FindByEmailAsync(appUserEmail);
                        if (appUser == null)
                        {
                            var newAppUser = new AppUser()
                            {
                                UserName = "app-user",
                                Email = appUserEmail,
                                EmailConfirmed = true,
                                Address = new Address()
                                {
                                    Street = "123 Main St",
                                    City = "Charlotte",
                                    State = "NC"
                                }
                            };
                            await userManager.CreateAsync(newAppUser, "Coding@1234?");
                            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                        }
                    }
                }
                */
            }
        }
    }
}
