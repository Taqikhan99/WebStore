using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebAppStore.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        //[Remote(action: "IsEmailAlreadyInUse", controller: "Account")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must be same")]
        public string ConfirmPassword { get; set; }
    }
}
