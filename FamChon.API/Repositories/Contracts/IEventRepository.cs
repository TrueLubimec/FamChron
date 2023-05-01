using FamChron.API.Entities;

namespace FamChron.API.Repositories.Contracts
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEvents();
        Task<IEnumerable<Story>> GetStory();
        Task<Event> GetEvent(int id);
        Task<Story> GetStory(int id);
    }
}
