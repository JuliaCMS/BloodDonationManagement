using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonationManagement.Models
{
	public class AppUser : IdentityUser
	{
		[ForeignKey("Address")]
		public int? AddressId { get; set; }
		public virtual Address? Address { get; set; }

		[ForeignKey("BloodBank")]
		public int? BloodBankId { get; set; }
		public virtual BloodBank? BloodBank { get; set; }
	}
}
