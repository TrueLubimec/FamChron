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
                var products = await this.eventRepository.GetEvents(); 
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
