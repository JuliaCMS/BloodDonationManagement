using BloodDonationManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationManagement.DataAcessLayer
{
    public class DBContext : IdentityDbContext<AppUser>
    {
        public DbSet<BloodBank> BloodBanks { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }


        public DBContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configures database connection using JSON file
            var connectionString = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build()
                .GetConnectionString("DataBase");

            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
