using FamChron.Api.Repositories.Contracts;
using FamChron.Api.Data;
using FamChron.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace FamChron.Api.Repositories
{
    public class StorysEventsRepository : IStorysEventsRepository
    {
        private readonly FamChronDbContext famChronDbContext;

        public StorysEventsRepository(FamChronDbContext famChronDbContext)
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
