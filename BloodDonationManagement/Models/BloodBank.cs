using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonationManagement.Models
{
    public class BloodBank
    {
        [Key]
        public int Id { get; set; }

        public string Login { get; set; } = null!;

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Telephone { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public virtual Address? Address { get; set; }

        [ForeignKey("BloodInventory")]
        public int? BloodInventoryId { get; set; }
        public virtual BloodInventory? BloodInventory { get; set; }

        public virtual ICollection<DonationRequisition> Requisitions { get; set; } = new List<DonationRequisition>();
    }
}
