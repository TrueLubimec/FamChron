using FamChron.API.Data;
using FamChron.API.Entities;
using FamChron.API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FamChron.API.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly FamChronDbContext famChronDbContext;

        public EventRepository(FamChronDbContext famChronDbContext)
        {
            this.famChronDbContext = famChronDbContext;
        }
        public Task<Event> GetEvent(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            var events = await this.famChronDbContext.Events.ToListAsync();
            return events;
        }

        public async Task<IEnumerable<Story>> GetStory()
        {
            var stories = await this.famChronDbContext.Stories.ToArrayAsync();
            return stories;
        }

        public Task<Story> GetStory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
