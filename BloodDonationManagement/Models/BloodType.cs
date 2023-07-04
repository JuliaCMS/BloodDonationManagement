using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonationManagement.Models
{
    public class BloodType
    {
        [Key]
        public int Id { get; set; }

        public string AboRhType { get; set; }

    }
}
