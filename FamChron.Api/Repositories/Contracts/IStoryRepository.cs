using FamChron.Api.Entities;
using FamChron.Models.Dtos;

namespace FamChron.Api.Repositories.Contracts
{
    public interface IStoryRepository
    {
        Task<IEnumerable<Story>> GetStories();
        Task<Story> GetStory(int id);
        Task<Story> PostStory(StoryDto @story);
    }
}
