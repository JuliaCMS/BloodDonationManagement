using BloodDonationManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationManagement.DataAcessLayer
{
    public class DBContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<BloodBank> BloodBanks { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<BloodInventory> BloodInventories { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<DonationRequisition> Requisitions { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configures entity relationships and properties

            modelBuilder.Entity<BloodBank>()
                .HasOne(b => b.BloodInventory)
                .WithOne(i => i.BloodBank)
                .HasForeignKey<BloodInventory>(i => i.FkBloodBank)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BloodBank>()
                .HasMany(b => b.Requisitions)
                .WithOne(r => r.BloodBank)
                .HasForeignKey(r => r.FkBloodBank)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DonationRequisition>()
                .HasOne(r => r.Donor)
                .WithMany(d => d.Requisitions)
                .HasForeignKey(r => r.FkDonor)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
