using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonationManagement.Models
{
	public class AppUser : IdentityUser
	{
		public string? Name { get; set; }

		public string? Cnpj { get; set; }

		public string? Cpf { get; set; }

		public string? Telephone { get; set; }

		[ForeignKey("Address")]
		public int? AddressId { get; set; }
		public virtual Address? Address { get; set; }

		[ForeignKey("BloodInventory")]
		public int? BloodInventoryId { get; set; }
		public virtual BloodInventory? BloodInventory { get; set; }

		public virtual ICollection<Donor>? Donors { get; set; }

		public virtual ICollection<DonationRequisition>? Requisitions { get; set; } = new List<DonationRequisition>();
	}
}
