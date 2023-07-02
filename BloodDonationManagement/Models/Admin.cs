using System.ComponentModel.DataAnnotations;

namespace BloodDonationManagement.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        public string Login { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
