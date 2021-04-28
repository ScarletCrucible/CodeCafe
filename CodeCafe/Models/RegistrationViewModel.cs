using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace CodeCafe.Models.ViewModels
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Please enter your email address.")]
        [RegularExpression(".+@gmail.com", ErrorMessage = "Not a valid email.")]
        [StringLength(30, ErrorMessage = "Address cannot be longer than 20 characters.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Can only contain letters.")]
        [StringLength(20, ErrorMessage = "Username cannot be longer than 20 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        [Range(1000000000, 9999999999, ErrorMessage = "Phone Number must be 10 digits long without dashes.")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        [Compare("PasswordConfirmation")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please re-enter your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password Confirmation")]
        public string PasswordConfirmation { get; set; }
    }
}