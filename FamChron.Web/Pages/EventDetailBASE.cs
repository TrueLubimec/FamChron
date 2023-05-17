using FamChron.Models.Dtos;
using FamChron.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace FamChron.Web.Pages
{
    public class EventDetailBASE : ComponentBase
    {

        [Parameter]
        public int id { get; set; }

        [Inject]
        public IEventService eventService { get; set; }

        public EventDto anEvent { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                anEvent = await eventService.GetEvent(id);
            }
            catch (Exception except)
            {
                ErrorMessage = except.Message;
            }
        }
    }
}
