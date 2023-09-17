using FamChron.Api.Entities;
using FamChron.Api.Extensions;
using FamChron.Api.Repositories.Contracts;
using FamChron.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FamChron.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IStoryRepository storyRepository;

        public StoryController(IStoryRepository storyRepository)
        {
            this.storyRepository = storyRepository;
        }

        [HttpGet]
        [Route("{userId}/GerStories")]
        public async Task<ActionResult<IEnumerable<Story>>> GetStories()
        {
            try
            {
                var stories = await this.storyRepository.GetStories();
                if (stories == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(stories);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Pizdec ne robit (((");

            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Story>> GetStory(int id)
        {
            try
            {
                var story = await this.storyRepository.GetStory(id);
                if (story == null)
                {
                    return null;
                }
                else
                {
                    return Ok(story);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Oshibsya");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Story>> PostStory([FromBody] StoryDto @story)
        {
            try
            {
                var newStory = await this.storyRepository.PostStory(@story);
                if (newStory == null)
                {
                    return NoContent();
                }

                var aStory = await storyRepository.GetStory(newStory.id);

                if (aStory == null)
                {
                    throw new Exception($"Something went wrong when attempting to retrieve product (productId:({newStory.id})");
                }

                var newStoryDto = newStory.ConvertToDto();
                return CreatedAtAction(nameof(GetStory),new {id = newStoryDto.id}, newStoryDto);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }

}
