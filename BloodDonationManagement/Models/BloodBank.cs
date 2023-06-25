namespace BloodDonationManagement.Models
{
    public class BloodBank
    {
        public int Id { get; set; }

        public string Login { get; set; } = null!;

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual Address Adress { get; set; }

        public string Telephone { get; set; }

        public virtual BloodInventory? BloodInventory { get; set; }
        
        public virtual ICollection<DonationRequisition> Requisitions { get; set; } = new List<DonationRequisition>();
    }
}
