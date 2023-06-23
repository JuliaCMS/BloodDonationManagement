namespace BloodDonationManagement.Models
{
    public class DonationRequisition
    {
        public int Id { get; set; }

        public DateTime RequisitionDate { get; set; }

        public int FkDonor { get; set; }

        public int FkBloodBank { get; set; }

        public virtual BloodBank? BloodBank { get; set; }

        public virtual Donor? Donor { get; set; }
    }
}
