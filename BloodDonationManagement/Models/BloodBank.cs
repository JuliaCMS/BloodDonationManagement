using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonationManagement.Models
{
    public class BloodBank
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public virtual Address? Address { get; set; }
    }
}
