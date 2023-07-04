using BloodDonationManagement.Models;
using System.Diagnostics;

namespace BloodDonationManagement.ViewModels
{
    public class DashboardViewModel
    {
        public List<Donor> Donors { get; set; }
        public List<BloodBank> BloodBanks { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
