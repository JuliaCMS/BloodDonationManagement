using System.ComponentModel.DataAnnotations;

namespace BloodDonationManagement.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "E-mail Address")]
        [Required(ErrorMessage = "E-mail address is required")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
