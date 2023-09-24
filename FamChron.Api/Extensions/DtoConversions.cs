using FamChron.Api.Entities;
using FamChron.Models.Dtos;

namespace FamChron.Api.Extensions
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
                        PreviewPhotoURL = _event.PreviewPhoto,
                        dateTime = _event.Date,
                        Description= _event.Description
                    }).ToList();
        }

        public static EventDto ConvertToDto(this Event anEvent,
                                                 Story story)
        {
            return new EventDto
            {
                Id = anEvent.id,
                StoryID = story.id,
                EventName = anEvent.Name,
                PreviewPhotoURL = anEvent.PreviewPhoto,
                dateTime = anEvent.Date,
                Description = anEvent.Description
            };
        }

        public static StoryDto ConvertToDto(this Story story)
        {
            return new StoryDto
            {
                id = story.id,
                Name = story.Name
            };
        }

        public static UserDto ConvertToDto(this User user)
        {
            return new UserDto
            {
                UserId = user.id,
                Name = user.UserName,
                Password = user.PasswordHash
            };
        }
    }
}
