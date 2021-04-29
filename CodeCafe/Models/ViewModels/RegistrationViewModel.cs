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
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        [StringLength(10, ErrorMessage = "Phone Number must be 10 digits long without dashes.")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter a business hour.")]
        public string Hour { get; set; }

        [Required(ErrorMessage = "Please enter a minute of the business hour.")]
        public string Minute { get; set; }
    }
}