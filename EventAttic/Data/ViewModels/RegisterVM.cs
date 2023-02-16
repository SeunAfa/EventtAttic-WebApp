using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace EventAttic.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        [Microsoft.Build.Framework.Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [System.ComponentModel.DataAnnotations.Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
