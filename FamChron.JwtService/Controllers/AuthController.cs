using BCrypt.Net;
using FamChron.JwtService.Entities;
using FamChron.JwtService.JwtHandler.Contracts;
using FamChron.JwtService.Repositories.Contracts;
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

    // МБ ЧЕРЕЗ gRPC попробовать ??
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // public static User user = new User();
        private readonly IJwtHandler jwtHandler;

        public AuthController(IJwtHandler jwtHandler)
        {
            this.jwtHandler = jwtHandler;
        }

        [HttpPost]
        public async Task<ActionResult<UserAccount>> Authenticate([FromBody] AuthRequest authRequest)
        {
            try
            {
                var authResponse = await jwtHandler.CreateToken(authRequest);
                if (authRequest == null) return Unauthorized(); // СДЕЛАТЬ ОБРАБОТКУ ОШИБОК
                return Ok(authResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        //[HttpPost("login")]
        //public async Task<ActionResult<UserAccount>> AddToken(UserDto userDtoRequest)
        //{
        //    var user = new User{
        //                                id = userDtoRequest.UserId,
        //                                UserName = userDtoRequest.Name,
        //                                PasswordHash = userDtoRequest.Password
        //                            };
        //    var loginUser = await authRepository.Login(user);
        //    // лучше сделать один тест или одинаковые сообщения, чтобы сложнее ломануть
        //    if (loginUser == null)
        //    {
        //        return BadRequest("User not found.");
        //    }
        //    // loginUser.Result.PasswordHash
        //    if (!BCrypt.Net.BCrypt.Verify(userDtoRequest.Password, loginUser.PasswordHash))
        //    {
        //        return BadRequest("Wrong password.");
        //    }

        //    string token = CreateToken(user);

        //    return Ok(token);
        //}
    }
}
