using FamChron.Api.Data;
using FamChron.Api.Entities;
using FamChron.Api.Repositories.Contracts;
using FamChron.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace FamChron.Api.Repositories
{
    public class StoryRepository : IStoryRepository
    {
        private readonly FamChronDbContext famChronDbContext;

        public StoryRepository(FamChronDbContext famChronDbContext)
        {
            this.famChronDbContext = famChronDbContext;
        }

        private async Task<bool> StoryExist (int id)
        {
            return await this.famChronDbContext.Stories.AllAsync(a => a.id == id);
        }


        public async Task<IEnumerable<Story>> GetStories()
        {
            var stories = await this.famChronDbContext.Stories.ToListAsync();
            return stories;
        }

        public async Task<Story> GetStory(int id)
        {
            var aStory = await this.famChronDbContext.Stories.FindAsync(id);
            return aStory;
        }

        public async Task<Story> PostStory(StoryDto @story)
        {
            var item = new Story
            {
                id = story.id,
                Name = story.Name
            };
            if (@story != null)
            {
                var result = await this.famChronDbContext.Stories.AddAsync(item);
                await this.famChronDbContext.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }
    }
}
