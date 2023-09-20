using FamChron.Api.Data;
using FamChron.Api.Entities;
using FamChron.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FamChron.Api.Repositories
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

        public async Task<IEnumerable<Event>> GetEvents(int storyId)
        {
            var events = await this.famChronDbContext.Events.Where(a => EF.Property<int?>(a, "StoryId") == storyId).ToListAsync();
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
