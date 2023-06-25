namespace BloodDonationManagement.Models
{
    public class Donor
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Cpf { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual Address Adress { get; set; }

        public string Telephone1 { get; set; }

        public string? Telephone2 { get; set; }

        public virtual BloodType BloodType { get; set; }

        public DateTime? LastDonation { get; set; }

        public virtual ICollection<DonationRequisition> Requisitions { get; set; } = new List<DonationRequisition>();
    }
}
