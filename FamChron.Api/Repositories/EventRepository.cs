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
        private async Task<bool> EventExists(int eventId, int storyId)
        {
            return await this.famChronDbContext.Events.AnyAsync(c => c.id == eventId &&
                                                                c.StoryID == storyId);

        }
        public async Task<Event> AddEvent(Event @event)
        {
            if (await EventExists(@event.id, @event.StoryID) == false)
            {
                if (@event != null)
                {
                    var result = await this.famChronDbContext.Events.AddAsync(@event);
                    await this.famChronDbContext.SaveChangesAsync();
                    return result.Entity;
                }
            }
            return null;
        }

        public async Task<Event> GetEvent(int id)
        {
            var anEvent = await this.famChronDbContext.Events.FindAsync(id);
            return anEvent;
        }

        public async Task<IEnumerable<Event>> GetEvents(int StoryId)
        {
            return await (from events in famChronDbContext.Events
                          join Story in this.famChronDbContext.Stories
                          on events.StoryID equals Story.id
                          where Story.id == StoryId
                          select new Event
                          {
                              id = events.id,
                              Name = events.Name,
                              Date = events.Date,
                              Description = events.Description,
                              PreviewPhoto = events.PreviewPhoto,
                              Photos = events.Photos,
                              StoryID = events.StoryID
                          }).ToListAsync();
        }

        public async Task<Event> RemoveEvent(int id)
        {
            var item = await this.famChronDbContext.Events.FindAsync(id);
            if (item != null)
            {
                this.famChronDbContext.Events.Remove(item);
                this.famChronDbContext.SaveChangesAsync();
            }
            return item;
        }

        public Task<Event> UpdateEvents(Event @event)
        {
            throw new NotImplementedException();
        }
    }
}
