using FamChron.Api.Entities;
using FamChron.Api.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FamChron.Api.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var result = userRepository.GetUser(id);
                if (result == null)
                {
                    return NoContent();
                }
                
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
