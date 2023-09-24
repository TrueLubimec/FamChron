using System.ComponentModel.DataAnnotations;

namespace FamChron.Models.UIModels
{
    public class FormStory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Story's name is too long!")]
        [MinLength(1, ErrorMessage = "Story's name is too short!")]
        public string Name { get; set; }
    }
}
