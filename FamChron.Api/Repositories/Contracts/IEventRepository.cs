using FamChron.Api.Entities;

namespace FamChron.Api.Repositories.Contracts
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEvents();
        Task<IEnumerable<Story>> GetStories();
        Task<Event> GetEvent(int id);
        Task<Story> GetStory(int id);
    }
}
