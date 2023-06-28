using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonationManagement.Models
{
    public class Donor
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

        public string Telephone { get; set; }

        [ForeignKey("BloodType")]
        public int BloodTypeId { get; set; }
        public virtual BloodType BloodType { get; set; }

        public DateTime? LastDonation { get; set; }

        public virtual ICollection<DonationRequisition> Requisitions { get; set; } = new List<DonationRequisition>();
    }
}
