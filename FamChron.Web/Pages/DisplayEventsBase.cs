using FamChron.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace FamChron.Web.Pages
{
    public class DisplayEventsBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<EventDto> Events { get; set; } 
    }
}
