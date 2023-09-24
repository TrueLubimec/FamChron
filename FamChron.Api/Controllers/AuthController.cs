using FamChron.Api.Entities;
using FamChron.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamChron.Api.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();

        [HttpPost("register")]
        public ActionResult<User> Register (UserDto userDtoRequest)
        {
            string passwordHash
                = BCrypt.Net.BCrypt.HashPassword(userDtoRequest.Password);

            user.UserName = userDtoRequest.Name;
            user.PasswordHash = passwordHash;

            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<User> Login(UserDto userDtoRequest)
        {
            if (user.UserName != userDtoRequest.Name)
            {
                return BadRequest("User not found.");
            }
            if (!BCrypt.Net.BCrypt.Verify(userDtoRequest.Password, user.PasswordHash))
            {
                return BadRequest("Wrong password.");
            }

            return Ok(user);
        }
    }
}
