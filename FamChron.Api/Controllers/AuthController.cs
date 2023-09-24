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
    }
}
