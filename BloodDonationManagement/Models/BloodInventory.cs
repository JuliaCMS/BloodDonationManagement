using System.ComponentModel.DataAnnotations;

namespace BloodDonationManagement.Models
{
    public class BloodInventory
    {
        [Key]
        public int Id { get; set; }

        public virtual BloodBank? BloodBank { get; set; }

        public virtual ICollection<BloodType> Components { get; set; }
    }
}
