using FamChron.API.Entities;
using FamChron.Models.Dtos;

namespace FamChron.API.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<EventDto> ConvertToDto(this IEnumerable<Event> events,
                                                         IEnumerable<Story> stories)
        {
            return (from _event in events
                    join story in stories
                    on _event.StoryID equals story.id
                    select new EventDto
                    {
                        Id = _event.id,
                        StoryID = story.id,
                        EventName = _event.Name,
                        PreviewPhotoURL = _event.PreviewPhoto
                    }).ToList();
        }
    }
}
