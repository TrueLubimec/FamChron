using FamChron.Web.Pages;

namespace FamChron.Web.Services.Contracts
{
    public interface IStorysEventService
    {
        Task<IEnumerable<Event>> GetAllEvents(int storyId);
        
        // Task<Event> GetEvent(int id);

        Task<Event> PostEvent(Event @event);

    }
}
