using System.ComponentModel.DataAnnotations;

namespace BloodDonationManagement.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int RegisteredId { get; set; }

        [Required]
        public string UserType { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
