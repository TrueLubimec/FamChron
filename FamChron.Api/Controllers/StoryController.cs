using FamChron.Api.Entities;
using FamChron.Api.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamChron.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IEventRepository storyRepository;

        public StoryController(IEventRepository storyRepository)
        {
            this.storyRepository = storyRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Story>>> GetStory()
        {
            try
            {
                var story = await this.storyRepository.GetStories();
                if(story == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(story);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Pizdec ne robit (((");
                
            }
        }
    }

}
