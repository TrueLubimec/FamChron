using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamChron.Models.Dtos
{
    public class EventDto
    {
        public int Id { get; set; }
        public int EventID { get; set; }
        public string EventName { get; set;}
        public string PreviewPhotoURL { get; set;}

    }
}
