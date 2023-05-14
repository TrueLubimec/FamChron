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
        public async Task<Event> GetEvent(int id)
        {
            var anEvent = await this.famChronDbContext.Events.FindAsync(id);
            return anEvent;
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            var events = await this.famChronDbContext.Events.ToListAsync();
            return events;
        }

        public async Task<IEnumerable<Story>> GetStories()
        {
            var stories = await this.famChronDbContext.Stories.ToArrayAsync();
            return stories;
        }

        public async Task<Story> GetStory(int id)
        {
            var story = await famChronDbContext.Stories.SingleOrDefaultAsync(a => a.id == id);
            return story;
        }
    }
}
