using FamChron.Api.Entities;

namespace FamChron.Api.Repositories.Contracts
{
    public interface IStorysEventsRepository
    {
        Task<Event> AddEvent(Event @event);
        Task<Event> RemoveEvent(int id);
        Task<Event> UpdateEvents(Event @event);
        Task<Event> GetEvent(int id);
        Task<IEnumerable<Event>> GetAllEvents(int StoryId);

    }
}
