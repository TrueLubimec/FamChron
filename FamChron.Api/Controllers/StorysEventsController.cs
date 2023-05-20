using FamChron.Api.Entities;
using FamChron.Api.Repositories.Contracts;
using FamChron.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamChron.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorysEventsController : ControllerBase
    {
        private readonly IStorysEventsRepository storysEventsRepository;
        private readonly IEventRepository eventRepository;

        public StorysEventsController(IStorysEventsRepository storysEventsRepository,
                                      IEventRepository eventRepository)
        {
            this.storysEventsRepository = storysEventsRepository;
            this.eventRepository = eventRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetItems(int storyId)
        {
            try
            {
                var events = await this.storysEventsRepository.GetAllEvents(storyId);
                
                if (events == null)
                {
                    return NoContent();
                }
                return Ok(events);
                
            }
            catch (Exception except)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, except.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Event>> GetItem(int id)
        {
            try
            {
                var result = await this.storysEventsRepository.GetEvent(id);
                if (result == null)
                {
                    return NoContent();
                }
                return Ok(result);
            }
            catch (Exception except)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, except.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent([FromBody] Event @event)
        {
            try
            {
                var newEvent = await this.storysEventsRepository.AddEvent(@event);
                if (newEvent == null)
                {
                    return NoContent();
                }
                return CreatedAtAction(nameof(GetItem), new { id = newEvent.id}, newEvent);
            }
            catch (Exception except)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, except.Message);
            }
        }

    }
}
