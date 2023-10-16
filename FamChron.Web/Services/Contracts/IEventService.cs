using FamChron.Models.Dtos;
using FamChron.Web.Pages;

namespace FamChron.Web.Services.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetEvents(int storyId);
        Task<EventDto> GetEvent(int id);
        Task<EventDto> PostEvent(EventDto @event);
    }
}
