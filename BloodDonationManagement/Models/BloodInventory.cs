namespace BloodDonationManagement.Models
{
    public class BloodInventory
    {
        public int Id { get; set; }

        public virtual BloodType? BloodType { get; set; }

        public int Quantity { get; set; }

        public int FkBloodBank { get; set; }

        public virtual BloodBank BloodBank { get; set; } = null!;
    }
}
