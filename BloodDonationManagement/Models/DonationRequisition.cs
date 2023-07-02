using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonationManagement.Models
{
    public class DonationRequisition
    {
        [Key]
        public int Id { get; set; }

        public string RequisitionDate { get; set; }

        [ForeignKey("BloodBank")]
        public int? BloodBankId { get; set; }
        public virtual BloodBank? BloodBank { get; set; }

        [ForeignKey("Donor")]
        public int? DonorId { get; set; }
        public virtual Donor? Donor { get; set; }
    }
}
