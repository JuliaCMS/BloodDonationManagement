using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonationManagement.Models
{
    public class DonationRequisition
    {
        public int Id { get; set; }

        public DateTime RequisitionDate { get; set; }

        [ForeignKey("BloodBank")]
        public int BloodBankId { get; set; }
        public virtual BloodBank BloodBank { get; set; }

        [ForeignKey("Donor")]
        public int DonorId { get; set; }
        public virtual Donor Donor { get; set; }
    }
}
