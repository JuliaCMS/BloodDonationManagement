using System.ComponentModel.DataAnnotations;

namespace BloodDonationManagement.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "E-mail Address")]
        [Required(ErrorMessage = "E-mail address is required.")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do no match.")]
        public string ConfirmPassword { get; set; }
    }
}
