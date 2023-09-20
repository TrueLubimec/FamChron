using FamChron.Models.Dtos;

namespace FamChron.Web.Services.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetEvents(int storyId);
        Task<EventDto> GetEvent(int id);
    }
}
