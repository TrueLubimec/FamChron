
using FamChron.Models.Dtos;

namespace FamChron.Web.Services.Contracts
{
    public interface IStoryService
    {
        Task<StoryDto> GetStory(int storyId);

        Task<StoryDto> PostStory(StoryDto @story);
    }
}
