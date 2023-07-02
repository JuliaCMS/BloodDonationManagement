using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonationManagement.Models
{
    public class Donor
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Cpf { get; set; }

        public string DateOfBirth { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public string? LastDonation { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public virtual Address? Address { get; set; }

        [ForeignKey("BloodType")]
        public int? BloodTypeId { get; set; }
        public virtual BloodType? BloodType { get; set; }

        [ForeignKey("BloodBankAppUser")]
        public string? BloodBankAppUserId { get; set; }
        public virtual AppUser? BloodBankAppUser { get; set; }

        public virtual ICollection<DonationRequisition> Requisitions { get; set; } = new List<DonationRequisition>();
    }
}
