using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamChron.Models.Dtos
{
    // Тип трансферный объект (в Api.Extemsions трансформируется) для передачи только необходимых данных
    public class EventDto
    {
        public int Id { get; set; }
        public int StoryID { get; set; }
        public string EventName { get; set;}
        public string PreviewPhotoURL { get; set;}
        public DateTime dateTime { get; set; }
        public string Description { get; set; }
    }
}
