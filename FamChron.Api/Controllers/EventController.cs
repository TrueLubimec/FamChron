using FamChron.API.Extensions;
using FamChron.API.Repositories.Contracts;
using FamChron.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamChron.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository eventRepository;
        public EventController(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents() 
        {
            try
            {
                var events = await this.eventRepository.GetEvents();
                var story = await this.eventRepository.GetStories();

                if (events == null || story == null) 
                {
                    return NotFound(); 
                }
                else 
                {
                    var eventDtos = events.ConvertToDto(story);
                    return Ok(eventDtos); 
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                            "PIZDEC SNOVA NE BACHIT");
                
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EventDto>> GetEvent(int id)
        {
            try
            {
                var anEvent = await this.eventRepository.GetEvent(id);

                if (anEvent == null)
                {
                    return NotFound();
                }
                else
                {
                    var story = await this.eventRepository.GetStory(anEvent.StoryID);

                    return Ok();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                            "PIZDEC SNOVA NE BACHIT");

            }
        }
    }
}
