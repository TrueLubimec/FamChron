using FamChron.Api.Repositories.Contracts;
using FamChron.Api.Data;
using FamChron.Api.Entities;

namespace FamChron.Api.Repositories
{
    public class StorysEventsRepository : IStorysEventsRepository
    {
        public StorysEventsRepository(FamChronDbContext famChronDbContext)
        {
            
        }
        public Task<Event> AddEvent(Event @event)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Event>> GetAllEvents()
        {
            throw new NotImplementedException();
        }

        public Task<Event> GetEvent(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Event> RemoveEvent(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Event> UpdateEvents(Event @event)
        {
            throw new NotImplementedException();
        }
    }
}
