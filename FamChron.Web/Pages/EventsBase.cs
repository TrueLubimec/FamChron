using FamChron.Models.Dtos;
using FamChron.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace FamChron.Web.Pages
{
    public class EventsBase : ComponentBase
    {
        [Inject]
        public IEventService eventService { get; set; }
        
        public IEnumerable<EventDto> events { get; set; }

        protected override async Task OnInitializedAsync()
        {
            events = await eventService.GetEvents();
        }
    }
}
