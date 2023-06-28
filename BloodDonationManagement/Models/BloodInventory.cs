using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonationManagement.Models
{
    public class BloodInventory
    {
        [Key]
        public int Id { get; set; }

        public string ComponentType { get; set; }

        public string BloodType { get; set; }

        public int Quantity { get; set; }
    }
}
