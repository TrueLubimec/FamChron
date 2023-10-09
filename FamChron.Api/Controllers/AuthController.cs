using FamChron.Api.Entities;
using FamChron.Api.Repositories.Contracts;
using FamChron.Models.Dtos;
using FamChron.Models.UIModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FamChron.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly IAuthRepository authRepository;

        public AuthController(IConfiguration configuration, IAuthRepository authRepository)
        {
            _configuration = configuration;
            this.authRepository = authRepository;
        }

        [HttpPost]
        public ActionResult<User> Register ([FromBody]RegistrationUserDto userDtoRequest)
        {
            try
            {
                var newUser = this.authRepository.Regitration(userDtoRequest);
                if (newUser == null)
                {
                    return NoContent();
                }
                return Ok(newUser);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost("login")]
        public ActionResult<User> Login(UserDto userDtoRequest)
        {
            // лучше сделать один тест или одинаковые сообщения, чтобы сложнее ломануть
            if (user.UserName != userDtoRequest.Name)
            {
                return BadRequest("User not found.");
            }
            if (!BCrypt.Net.BCrypt.Verify(userDtoRequest.Password, user.PasswordHash))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(user);

            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                                       _configuration.GetSection("Jwt:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
