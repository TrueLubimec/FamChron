﻿using FamChron.Api.Entities;
using FamChron.Api.Extensions;
using FamChron.Api.Repositories.Contracts;
using FamChron.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamChron.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository eventRepository;
        private readonly IStoryRepository storyRepository;

        public EventController(IEventRepository eventRepository, IStoryRepository storyRepository)
        {
            this.eventRepository = eventRepository;
            this.storyRepository = storyRepository;
        }

        [HttpGet("story{storyId:int}")]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents(int storyId)
        {
            try
            {
                var events = await this.eventRepository.GetEvents(storyId);
                var story = await this.storyRepository.GetStories();

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
                    return NoContent();
                }
                else
                {
                    var story = await this.storyRepository.GetStory(anEvent.StoryID);

                    var eventDto = anEvent.ConvertToDto(story);

                    return Ok(eventDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                            "PIZDEC SNOVA NE BACHIT");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent([FromBody] Event @event)
        {
            try
            {
                var newEvent = await this.eventRepository.AddEvent(@event);
                if (newEvent == null)
                {
                    return NoContent();
                }
                return CreatedAtAction(nameof(GetEvent), new { id = newEvent.id }, newEvent);
            }
            catch (Exception except)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, except.Message);
            }
        }
    }
}
