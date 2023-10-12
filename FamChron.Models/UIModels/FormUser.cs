using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamChron.Models.UIModels
{
    public class FormUser
    {
        public int UserId { get; set; }

        [Display(Name = "your nickname")]
        [Required]
        [StringLength(30, ErrorMessage ="Name is too long")]
        [MinLength(1, ErrorMessage ="Invalid name")]
        public string Name { get; set; }

        [Display(Name = "password")]
        [Required]
        public string Password { get; set; }
    }
}
