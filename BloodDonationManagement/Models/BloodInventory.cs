using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonationManagement.Models
{
    public class BloodInventory
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<BloodType> Components { get; set; }
    }
}
