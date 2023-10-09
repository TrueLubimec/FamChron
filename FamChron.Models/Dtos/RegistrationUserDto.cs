using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamChron.Models.Dtos
{
    public class RegistrationUserDto
    {
        public int Id { get; set; }

        [Display(Name = "Your name")]
        [Required]
        [StringLength(30, ErrorMessage = "Name is too long")]
        [MinLength(1, ErrorMessage = "Invalid name")]
        public string Name { get; set; }

        [Display(Name = "Email address")]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address!")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Confirm your password")]
        [Required]
        [Compare(nameof(Password), ErrorMessage = "The passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
