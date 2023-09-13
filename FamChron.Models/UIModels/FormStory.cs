using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamChron.Models.UIModels
{
    public class FormStory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Story's name is too long!")]
        [MinLength(0, ErrorMessage = "Story's name is too short!")]
        public string Name { get; set; }
    }
}
