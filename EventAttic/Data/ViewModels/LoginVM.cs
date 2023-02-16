using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace EventAttic.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email Address")]
        //[Required(ErrorMessage = "Email address is required")]
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
