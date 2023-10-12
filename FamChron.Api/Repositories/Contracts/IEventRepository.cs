using FamChron.Api.Entities;

namespace FamChron.Api.Repositories.Contracts
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEvents(int storyId);
        Task<Event> GetEvent(int id);
        Task<Event> AddEvent(Event @event);
        Task<Event> RemoveEvent(int id);
        Task<Event> UpdateEvents(Event @event);
    }
}
