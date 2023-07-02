using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonationManagement.Models
{
    public class BloodType
    {
        [Key]
        public int Id { get; set; }

        public string AboRhType { get; set; }

        public string? BloodComponentType { get; set; }

        public int? Quantity { get; set; }

        [ForeignKey("BloodInventory")]
        public int? BloodInventoryId { get; set; }
        public virtual BloodInventory? BloodInventory { get; set; }
    }
}
