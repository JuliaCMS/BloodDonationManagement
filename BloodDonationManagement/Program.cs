using BloodDonationManagement.DataAcessLayer;
using BloodDonationManagement.Interfaces;
using BloodDonationManagement.Models;
using BloodDonationManagement.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace BloodDonationManagement
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

                // Interfaces Injection
            builder.Services.AddScoped<IDonorRepository, DonorRepository>();
            builder.Services.AddScoped<IBloodBankRepository, BloodBankRepository>();

                // DbContext Injection
            builder.Services.AddDbContext<DBContext>();

                // Identity Injection and Authentication
            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<DBContext>();
            builder.Services.AddMemoryCache();
            builder.Services.AddSession();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

            var app = builder.Build();

                // Data Seed
            if (args.Length == 1 && args[0].ToLower() == "seeddata")
            {
				await Seed.SeedUsersAndRolesAsync(app);
                //Seed.SeedData(app);
            }


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // user authentication
            app.UseAuthorization(); // user permissions

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}